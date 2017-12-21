using System;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Collections.Generic;

namespace SciBuy.Models
{
    public class AppUser : IdentityUser
    {
        public string RealName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Page> Pages { get; set; } 
        public virtual ICollection<MetaField> User_Meta { get; set; }
    }
    public class MetaField
    {
        public int MetaFieldId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}