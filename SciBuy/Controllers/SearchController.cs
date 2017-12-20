using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SciBuy.Infrastructure.Abstract;
using SciBuy.Models;

namespace SciBuy.Controllers
{
    public class SearchController : Controller
    {
        IRepository repository;
        public SearchController(IRepository repos)
        {
            repository = repos;
        }
        // GET: Search
        public ActionResult Index(string title)
        {
            IEnumerable<Article> result =  repository.Articles.Where(x => x.Title.Contains(title));
            if (result.Count()==0)
                result = repository.Articles.Where(x => x.Content.Contains(title));
            return View(result);
        }
    }
}