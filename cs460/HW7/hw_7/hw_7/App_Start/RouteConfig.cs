using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hw_7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //find acts as a query string for the specific search
            routes.MapRoute(
                name: "MyRoute",
                url: "{gif}/{action}/{find}",
                defaults: new {controller = "Gif", action = "Search", find = UrlParameter.Optional }
            );
        }
    }
}
