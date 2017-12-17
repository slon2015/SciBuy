﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Models
{
    public class Article
    {
        public string Name;
        public string Content;
        public int AuthorID;
        public int ArticleID;
    }
}
