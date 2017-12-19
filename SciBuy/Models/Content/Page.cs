using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciBuy.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SciBuy.Models
{
    public class Page
    {
        public int PageId { get; set; }
        public string Content { get; set; }
        public DateTime CreatingDate { get; set; }
        public string Title { get; set; }
        public virtual AppUser Author { get; set; }
    } 
}
