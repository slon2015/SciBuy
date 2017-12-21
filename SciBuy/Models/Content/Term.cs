using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciBuy.Models.Content
{
    public class Term
    {
        public int TermId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Page> Pages { get; set; }
    }
}