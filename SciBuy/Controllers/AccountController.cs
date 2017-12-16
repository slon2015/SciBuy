using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using SciBuy.Infrastructure;
using SciBuy.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace SciBuy.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {          
            return View(CurrentUser);
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }

            ViewBag.returnUrl = returnUrl;
            return View();
        }
       
        [AllowAnonymous]
        public ActionResult Registration()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {
            AppUser user = await UserManager.FindByNameAsync(model.LoginName);
            if (user != null)
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            else
            if (ModelState.IsValid)
            {
                user = new AppUser {
                    UserName = model.LoginName,
                    Email = model.Email,
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
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        {
            AppUser user = await UserManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                return Redirect(returnUrl);
            }

            return View(details);
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
            {
                ModelState.AddModelError("", error);
                }
        }
    }
}