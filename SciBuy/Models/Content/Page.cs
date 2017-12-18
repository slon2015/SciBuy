using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciBuy.Models;

namespace SciBuy.Models
{
    public class Page
    {
        public int PageId { get; set; }
        public string Content { get; set; }
        public DateTime CreatingDate { get; set; }
        public string Title { get; set; }
        public AppUser Author { get; set; }
    } 
}
