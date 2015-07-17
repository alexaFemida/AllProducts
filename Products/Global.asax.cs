using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Products.Modules;

namespace Products
{
   public class MvcApplication : HttpApplication
   {
      protected void Application_Start()
      {
         var builder = new ContainerBuilder();
         builder.RegisterControllers(Assembly.GetExecutingAssembly());
         builder.RegisterModule<ProductsModule>();
         var container = builder.Build();
         DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
      protected void Application_Error(object sender, EventArgs e)
      {
         Server.ClearError();
         Response.Redirect("Views/Shared/Error.cshtml");
      }
   }
}