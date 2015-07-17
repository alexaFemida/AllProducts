using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Products.Helpers;
using Products.Models;
using Products.Services;

namespace Products.Controllers
{
   public class ProductController : Controller
   {
      readonly IProductService _productService;

      public ProductController(IProductService productService)
      {
         _productService = productService;
      }
      public ActionResult Index()
      {
         return View();
      }
      public ActionResult AjaxHandler(jQueryDataTableParamModel param)
      {
         var allProducts = _productService.GetAll().ToList();
         var displayedCompanies = _productService.GetPagedProducts(
            param.iDisplayStart, param.iDisplayLength);

         var result = from c in displayedCompanies
                      select new[] { c.Name.ToString(), c.ArrivalDate.ToString(), c.Price.ToString(), c.Count.ToString(), c.IsPromo.ToString()};

         return Json(new
         {
            sEcho = param.sEcho,
            iTotalRecords = allProducts.Count(),
            iTotalDisplayRecords = allProducts.Count(),
            aaData = result
         },
                             JsonRequestBehavior.AllowGet);
      }
      public int AddData(string name, string arrivalDate, string price, string count, string isPromo)
      {
         var newProduct = new Product()
                          {
                             Name = name,
                             ArrivalDate = Convert.ToDateTime(arrivalDate),
                             Price = Convert.ToDecimal(price),
                             Count = Convert.ToInt32(count)
                          };
         return _productService.Insert(newProduct);
      }
      public ActionResult ProductList(int currentPage, int pageItemsCount, string searchString)
      {
         var productList = _productService.GetProducts(currentPage, pageItemsCount, searchString);

         return PartialView(productList);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Create(Product product)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _productService.Insert(product);
               return RedirectToAction("Index");
            }
         }
         catch (DataException)
         {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
         }
         return View(product);
      }
      public ActionResult Edit(int id)
      {
         var product = _productService.Get(id);
         return View(product);
      }

      [HttpPost]
      public ActionResult Edit(Product product)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _productService.Update(product);
               return RedirectToAction("Index");
            }
         }
         catch (DataException)
         {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
         }
         return View(product);
      }
      public ActionResult Delete(int id, bool? saveChangesError)
      {
         if (saveChangesError.GetValueOrDefault())
         {
            ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
         }
         Product product = _productService.Get(id);
         return View(product);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
         try
         {
            _productService.Delete(id);
         }
         catch (DataException)
         {
            return RedirectToAction("Delete",
                new RouteValueDictionary { 
                { "id", id }, 
                { "saveChangesError", true } });
         }
         return RedirectToAction("Index");
      }
   }
}