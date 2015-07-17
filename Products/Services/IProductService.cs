using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Models;

namespace Products.Services
{
   public interface IProductService
   {
      IEnumerable<Product> GetAll();
      int GetTotalCount();
      IEnumerable<Product> GetPagedProducts(int startPage, int countPerPage);
      PagedData<Product> GetProducts(int currentPage, int pageSize, string searchString);
      Product Get(int productId);
      int Insert(Product product);
      void Delete(int productId);
      void Update(Product product);
   }
}
