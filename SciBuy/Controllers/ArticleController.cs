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
using SciBuy.Infrastructure.Abstract;

namespace SciBuy.Controllers
{
    public class ArticleController : Controller
    {
        IRepository repos;
        public ArticleController(IRepository r)
        {
            repos = r;
        }
        public ViewResult Index(int id=0)
        {
            Article article = repos.Articles.FirstOrDefault(x => x.PageId == id);   
            if (article != null)
                return View(article);
            return View("Error", new string[] { "Статья" });
        }
        [HttpGet]
        [Authorize]
        public ViewResult CreateArticle(int ArtId = 0)
        {
            CreateArticleViewModel model = new CreateArticleViewModel();
            if (ArtId != 0)
            {
                Article article = repos.Articles.FirstOrDefault(a => a.PageId == ArtId);
                if (article != null)
                {
                    model.Name = article.Title;
                    model.Content = article.Content;
                    model.ArticleID = article.PageId;
                    model.Author = article.Author;
                }
            }
            return View(model);
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
                Author = UserManager.FindByName(HttpContext.User.Identity.Name),
                CreatingDate = DateTime.Now
            };
            ///////////////////////////////////////////


            //Сохраняем созданную/измененную статью здесь.

            repos.Save(current);

            ///////////////////////////////////////////
            return RedirectToAction("Complete");
        }
        [Authorize]
        public ActionResult Delete(int ArtId)
        {
            Article article = repos.Articles.FirstOrDefault(x => x.PageId == ArtId);
            ///////////////////////////////////////////


            //Сохраняем созданную/измененную статью здесь.

            repos.Save(article);

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

        [AllowAnonymous]
        public ViewResult List()
        {
            return View(repos.Articles);
        }
    }
}