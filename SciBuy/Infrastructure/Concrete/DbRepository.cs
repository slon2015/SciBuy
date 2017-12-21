using SciBuy.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciBuy.Models;
using Microsoft.AspNet.Identity.Owin;
using SciBuy.Models.Content;

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
        public IEnumerable<Term> Terms
        {
            get
            {
                return context.Terms;
            }
        }
        public IEnumerable<Tag> Tags
        {
            get
            {
                return context.Terms.OfType<Tag>().AsEnumerable();
            }
        }
        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Terms.OfType<Category>().AsEnumerable();
            }
        }
        public void Save(Term term)
        {
            context.Terms.Add(term);
            context.SaveChanges();
        }
        public void Add(Article art)
        {
            context.Pages.Add(art);
            context.SaveChanges();
        }
        public void Save(Article art)
        {
            
        }
        public void Delete(Article art)
        {
            context.Pages.Remove(art);
            context.SaveChanges();
        }
    }
}