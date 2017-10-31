using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "Default1",
                url: "public/{controller}/{action}",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default3",
                url: "{controller}/{action}/{x}/{y}",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "Default4",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "Default", action = "Index",  }
            );

            routes.MapRoute(
                name: "Default5",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = "^D.*", action = "^Index& | ^About&", id = "^\\d+&"}
            );
        }
    }
}
