using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Products.DataAccess;
using Products.Models;

namespace Products.Services
{
   public class ProductService : IProductService
   {
      public IEnumerable<Product> GetAll()
      {
         using (var dataContext = new ProductContext())
         {
            return dataContext.Products.ToList();
         }
      }

      public int GetTotalCount()
      {
         using(var dataContext = new ProductContext()){
            var products = dataContext.Products.OrderBy(p => p.Name);
            return products.Count();
         }
      }

      public IEnumerable<Product> GetPagedProducts(int startPage, int countPerPage)
      {
         using (var dataContext = new ProductContext())
         {
            var products = dataContext.Products.OrderBy(p => p.Id);
            return products.Skip(startPage).Take(countPerPage).ToList();
         }
      }

      public PagedData<Product> GetProducts(int currentPage, int pageSize, string searchString)
      {
         using (var dataContext = new ProductContext())
         {
            var products = dataContext.Products.OrderBy(p => p.Name);

            if (!String.IsNullOrEmpty(searchString))
            {
               products = (IOrderedQueryable<Product>)products.Where(s => s.Name.Contains(searchString));
            }

            int totalItemsCount = products.Count();

            return new PagedData<Product>
            {
               TotalItemsCount = totalItemsCount,
               CurrentPage = currentPage,
               PageSize = pageSize,
               Data = products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
            };
         }
      }

      public Product Get(int productId)
      {
         using (var dataContext = new ProductContext())
         {
            return dataContext.Products.FirstOrDefault(p => p.Id == productId);
         }
      }

      public int Insert(Product product)
      {
         using (var dataContext = new ProductContext())
         {
            dataContext.Products.Add(product);
            dataContext.SaveChanges();
            return product.Id;
         }
      }

      public void Delete(int productId)
      {
         using (var dataContext = new ProductContext())
         {
            var productToDelete = new Product { Id = productId };
            dataContext.Products.Attach(productToDelete);
            dataContext.Products.Remove(productToDelete);
            dataContext.SaveChanges();
         }
      }

      public void Update(Product product)
      {
         using (var dataContext = new ProductContext())
         {
            dataContext.Products.AddOrUpdate(product);
            dataContext.SaveChanges();
         }
      }
   }
}