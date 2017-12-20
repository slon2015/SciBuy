using SciBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciBuy.Models.Content;

namespace SciBuy.Infrastructure.Abstract
{
    public interface IRepository
    {
        IEnumerable<Article> Articles { get; }
        IEnumerable<Term> Terms { get; }
        IEnumerable<Tag> Tags { get; }
        IEnumerable<Category> Categories { get; }


        void Save(Article art);
    }
}
