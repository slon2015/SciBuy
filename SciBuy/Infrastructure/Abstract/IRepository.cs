using SciBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciBuy.Infrastructure.Abstract
{
    public interface IRepository
    {
        IEnumerable<Article> Articles { get; }
        void Save(Article art);
    }
}
