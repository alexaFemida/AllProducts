using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Products
{
   public class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
         );
         routes.MapRoute(
            name: "Default2",
            url: "{controller}/{action}/{name}/{arrivalDate}/{price}/{count}/{isPromo}",
            defaults: new { controller = "Product", action = "AddData", name = UrlParameter.Optional, arrivalDate = UrlParameter.Optional, price = UrlParameter.Optional, count = UrlParameter.Optional, isPromo = UrlParameter.Optional }
        );
      }
   }
}
