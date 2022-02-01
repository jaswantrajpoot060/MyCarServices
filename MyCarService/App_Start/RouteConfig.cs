using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCarService
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Special",
                url: "{action}.html",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Special2",
                url: "{action}.html/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "DefaultM",
                url: "{controller}/{action}.html",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "DefaultMM",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index" }
            );

            //

            //routes.MapRoute(
            //    name: "DefaultSM",
            //    url: "{controller}/{action}.html",
            //    defaults: new { controller = "Sale", action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "DefaultSMM",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Sale", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
