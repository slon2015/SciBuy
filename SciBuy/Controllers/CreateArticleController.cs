using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SciBuy.Models;
using SciBuy.Domain;

namespace SciBuy.Controllers
{
    public class CreateArticleController : Controller
    {
        [HttpGet]
        [AllowAnonymous]//Временно доступно анонимным пользователям, пока никита не сделает нормальную регистрацию
        public ViewResult CreateArticle()
        {
            return View(new CreateArticleViewModel()
            {
                //AuthorID=1,
                author = new AppUser()
                {
                    UserName = "Slon",
                    Id = "1"
                },
                Name = "Test",
                ArticleID = 0,
                Content = ""
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateArticle(CreateArticleViewModel model)
        {
            Article current = new Article()
            {
                Name = model.Name,
                Content = model.Content,
                ArticleID = model.ArticleID,
                AuthorID = int.Parse(model.author.Id)
            };
            ///////////////////////////////////////////


            //Сохраняем созданную/измененную статью здесь.


            ///////////////////////////////////////////
            return RedirectToAction("Complete");
        }
    }
}