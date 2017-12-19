using SciBuy.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciBuy.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SciBuy.Infrastructure.Concrete
{
    public class DbRepository : IRepository
    {
        public DbRepository()
        {
            context = OwinContextExtensions.Get<AppIdentityDbContext>(HttpContext.Current.GetOwinContext());
        }
        AppIdentityDbContext context;
        public IEnumerable<Article> Articles
        {

            get
            {
                return context.Pages.OfType<Article>().AsEnumerable();
            }
        }

        public void Save(Article art)
        {
            context.Pages.Add(art);
            context.SaveChanges();
        }
    }
}