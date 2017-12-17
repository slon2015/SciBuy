using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SciBuy.Domain;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Models
{
    public class CreateArticleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArticleID { get; set; }
        public AppUser author { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}