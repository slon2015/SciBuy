using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SciBuy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(null,
            //    "",
            //    new
            //    {
            //        controller = "Account",
            //        action = "Index",
            //        username = 1
            //    }
            //);
            routes.MapRoute(
                name: null,
                url: "user/{username}",
                defaults: new { controller = "Account", action = "Index", username = (string)null }
                //constraints: new { page = @"\d+" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
