using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciBuy.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Moq;
using SciBuy.Infrastructure;

namespace SciBuy.App_Start
{
    public static class ContextGetter
    {
        public static AppIdentityDbContext GetDbContext()
        {
            Mock<AppIdentityDbContext> mock = new Mock<AppIdentityDbContext>();
            Mock<DbSet<AppUser>> users = new Mock<DbSet<AppUser>>();
            //users.
            users.Setup(m => m.AsEnumerable).Returns(new List<AppUser>() { new AppUser() { UserName = "Admin", PasswordHash = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4" } }.AsEnumerable());
            mock.Setup(m => m.Users).Returns( users.Object );
            return mock.Object;
        }
    }
}