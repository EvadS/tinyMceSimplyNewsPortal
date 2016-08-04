using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimplyNewsPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Pagination",
                url: "{controller}/{action}/page/{page}",
                defaults: new { controller = "Home", action = "List", page = 0 }
            );

            routes.MapRoute(
                name: "PaginationCategory",
                url: "{controller}/{action}/page/{page}/category/{category}",
                defaults: new { controller = "Home", action = "List", page = 0, category = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}