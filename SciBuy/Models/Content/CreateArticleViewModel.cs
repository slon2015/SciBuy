using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Models
{
    public class CreateArticleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArticleID { get; set; }
        public AppUser Author { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public CreateArticleViewModel()
        {
            ArticleID = 0;
            Name = "";
            Content = "";
            Author = null;
        }
    }
}