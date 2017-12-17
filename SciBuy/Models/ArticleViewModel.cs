using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Models
{
    public class ArticleViewModel
    {
        [Required(ErrorMessage="Имя статьи является обязательным.")]
        public string Name;
        public string Content;
        [Required]
        public int AuthorId;
        [Key]
        public int ArticleId;
    }
}