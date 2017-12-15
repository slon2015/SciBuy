using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SciBuy.Controllers
{
    public class ArticleCreatorController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
    }
}