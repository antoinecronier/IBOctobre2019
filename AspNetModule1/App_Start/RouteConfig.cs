using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetModule1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "ListEmployeesByProject",
                url: "Projects/{projectRef}",
                defaults: new { controller = "Employees", action = "ListEmployees" },
                constraints: new { projectRef = @"^[A-Z]{2}\d{5}$" }
                );

            routes.MapRoute(
                name: "ListEmployeesByName",
                url: "Employees/{nom}",
                defaults: new { controller = "Employees", action = "FindEmployees" }
                );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
