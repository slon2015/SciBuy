using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Domain.Models
{
    class Article
    {
        public string Name;
        public string Content;
        public int AuthorId;
        [Key]
        public int ArticleId;
    }
}
