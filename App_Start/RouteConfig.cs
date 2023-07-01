using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DBSchoolManagementSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminLogin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "AdminLogin", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "UserLogin",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
           );
        }
    }
}
