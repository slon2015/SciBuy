using SciBuy.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciBuy.Models;
using SciBuy.Models.Content;

namespace SciBuy.Infrastructure.Concrete
{
    public class StaticRepository : IRepository
    {
        List<Article> articlesList = new List<Article>();
        public IEnumerable<Article> Articles { get { return articlesList; } }

        public IEnumerable<Term> Terms => throw new NotImplementedException();

        public IEnumerable<Tag> Tags => throw new NotImplementedException();

        public IEnumerable<Category> Categories => throw new NotImplementedException();

        public void Save(Article art)
        {
            if (art.PageId == 0)
                articlesList.Add(art);
            else
            {
                Article current = articlesList.Find(a => a.PageId == art.PageId);
                if (current != null)
                    current = art;
                else
                    articlesList.Add(art);
            }
        }
    }
}