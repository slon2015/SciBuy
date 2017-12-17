using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using SciBuy.Infrastructure;
using SciBuy.Models;

namespace SciBuy.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            //Создаем словарь значений свойств для представления
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "E-mail",CurrentUser.Email },
                { "Логин",CurrentUser.UserName },
                { "Имя",CurrentUser.RealName },
                { "Дата регистрации",CurrentUser.RegistrationDate },
            };
            if (CurrentUser.User_Meta != null)
                foreach (var data in CurrentUser.User_Meta)
                    dict.Add(data.Name, data.Value);
            return View(dict);
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {           
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error", new string[] { "В доступе отказано" });
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        {
            //ищем пользоваетеля в бд
            AppUser user = await UserManager.FindAsync(details.Name, details.Password);
            if (user == null)
                ModelState.AddModelError("LoginError", "Некорректное имя или пароль.");
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                //Аунтетифицируем пользователя на основе куки
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                if (returnUrl == "" || returnUrl == null)
                    returnUrl = Url.Action("Index", "Home");
                return Redirect(returnUrl);
            }

            return View(details);
        }
        [AllowAnonymous]
        public ActionResult Registration()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error", new string[] { "В доступе отказано" });
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                
                AppUser user = new AppUser
                {
                    UserName = model.LoginName,
                    Email = model.Email.Trim(' '),
                    RealName = model.Name,
                    RegistrationDate = System.DateTime.Now
                };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ActionResult actionResult = await Login(new LoginViewModel() { Name = model.LoginName, Password = model.Password }, Url.Action("Index", "Home"));
                    return RedirectToAction("Index", "Home");
                }
                else
                    AddErrorsFromResult(result);
            }
            return View();
        }
        public ActionResult Edit()
        {
            return View(CurrentUser);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            AppUser user = CurrentUser;
            user.RealName = model.RealName;
            user.Email = model.Email.Trim(' ');
            //проверяем E-mail
            IdentityResult validEmail
                    = await UserManager.UserValidator.ValidateAsync(user);
            if (!validEmail.Succeeded)
                AddErrorsFromResult(validEmail);
            //проверяем пароль
            IdentityResult validPass = null;
            if (model.Password != null)
            {
                validPass
                    = await UserManager.PasswordValidator.ValidateAsync(model.Password);
                //обновляем пароль, если все корректно
                if (validPass.Succeeded)
                    CurrentUser.PasswordHash =
                        UserManager.PasswordHasher.HashPassword(model.Password);
                else
                    AddErrorsFromResult(validPass);
            }
            if ((validEmail.Succeeded && validPass == null) ||
                        (validEmail.Succeeded && model.Password != null && validPass.Succeeded))
            {
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    AddErrorsFromResult(result);
            }
            return View(user);

        }
        [HttpPost]
        public async Task<ActionResult> Delete()
        {
            AppUser user = CurrentUser;
            AuthManager.SignOut();
            IdentityResult result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                return View("Error", result.Errors);
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager
        {
            get
            {
               
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        private AppUser CurrentUser
        {
            get
            {
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
                ModelState.AddModelError("", error);
        }
    }
}