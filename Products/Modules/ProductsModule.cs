using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Products.Services;

namespace Products.Modules
{
   public class ProductsModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<ProductService>().As<IProductService>();
         base.Load(builder);
      }
   }
}