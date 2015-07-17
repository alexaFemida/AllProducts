using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Products.Models;

namespace Products.DataAccess
{
   public class ProductContext : DbContext
   {
      public ProductContext()
         : base("name=TestTaskProductsConnectionString")
      {
         Database.SetInitializer<ProductContext>(null);
      }

      public virtual DbSet<Product> Products { get; set; }
   }
}