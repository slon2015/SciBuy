﻿using SciBuy.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SciBuy.Models.Content;

namespace SciBuy.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {   
        public AppIdentityDbContext() : base("name=IdentityDb") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
        public DbSet<MetaField> User_Meta { get; set; }    
        public DbSet<Page> Pages { get; set; }
        public DbSet<Term> Terms { get; set; }
    }

    /*public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            // настройки конфигурации контекста будут указываться здесь
        }*/
    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
    {

    }
}