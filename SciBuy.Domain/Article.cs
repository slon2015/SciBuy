using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Domain
{
    public class Article
    {
        [Required]
        public string Name;
        public string Content;
        [Required]
        public int AuthorID;
        [Required]
        public int ArticleID;
    }
}
