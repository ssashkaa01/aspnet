using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebExams
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "{controller}/{action}",
                defaults: new { controller = "UserProfile", action = "Profile" }
            );
        }
    }
}
