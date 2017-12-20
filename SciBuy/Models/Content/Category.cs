using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SciBuy.Models.Content
{
    public class Category : Term
    {
        public Guid? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual IEnumerable<Category> Children { get; set; }
    }
}