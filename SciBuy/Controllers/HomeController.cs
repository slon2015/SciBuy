using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using SciBuy.Infrastructure;
using SciBuy.Models;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SciBuy.Infrastructure.Abstract;

namespace SciBuy.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;
        public HomeController(IRepository repos)
        {
            repository = repos;
        }
        public ActionResult Index()
        {
            return View(repository.Articles.OrderByDescending(x => x.CreatingDate).Take(5));
        }
        private AppUser CurrentUser
        {
            get
            {
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
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
