using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SciBuy.Models;
using SciBuy.Infrastructure;

namespace SciBuy.Controllers
{
    public class CreateArticleController : Controller
    {
        [HttpGet]
        [Authorize]//Временно доступно анонимным пользователям, пока никита не сделает нормальную регистрацию
        public ViewResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateArticle(CreateArticleViewModel model)
        {
            Article current = new Article()
            {
                Title = model.Name,
                Content = model.Content,
                PageId = model.ArticleID,
                Author = UserManager.FindByName(HttpContext.User.Identity.Name)
            };
            ///////////////////////////////////////////


            //Сохраняем созданную/измененную статью здесь.


            ///////////////////////////////////////////
            return RedirectToAction("Complete");
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}