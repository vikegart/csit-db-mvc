using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.Avards
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "InfoUserByName",
              url: "user/{name}",
              defaults: new { controller = "Users", action = "InfoUserByName" },
              constraints: new { name = @"^[A-Za-z_]+$" }
            );

            


            routes.MapRoute(
               name: "AddUserToAward",
               url: "award-user/{id}",
               defaults: new { controller = "Awards", action = "AddUserToAward" }
            );

            routes.MapRoute(
               name: "CreateUser",
               url: "create-user",
               defaults: new { controller = "Users", action = "CreateUser" }
            );


            routes.MapRoute(
               name: "InfoUser",
               url: "user/{id}",
               defaults: new { controller = "Users", action = "InfoUser" },
               constraints: new { id = @"^[0-9]+$" }
            );


            routes.MapRoute(
               name: "EditUser",
               url: "user/{id}/edit",
               defaults: new { controller = "Users", action = "EditUser" }
            );

            routes.MapRoute(
               name: "DeleteUser",
               url: "user/{id}/delete",
               defaults: new { controller = "Users", action = "DeleteUser" }
            );

            routes.MapRoute(
               name: "CreateAward",
               url: "create-award",
               defaults: new { controller = "Awards", action = "CreateAward" }
           );
            routes.MapRoute(
               name: "InfoAward",
               url: "award/{id}",
               defaults: new { controller = "Awards", action = "InfoAward" }
           );
            routes.MapRoute(
               name: "EditAward",
               url: "award/{id}/edit",
               defaults: new { controller = "Awards", action = "EditAward" }
           );
            routes.MapRoute(
               name: "DeleteAward",
               url: "award/{id}/delete",
               defaults: new { controller = "Awards", action = "DeleteAward" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
