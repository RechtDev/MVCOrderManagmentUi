using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCOrderManagmentUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly GSparkShopDBContext _context;
        public ProductController(GSparkShopDBContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult ViewProducts(string filterby, bool? des)
        {
            List<Product> Results = new List<Product>();
            switch (filterby)
            {
                case "none":
                    Results = _context.Products.ToList();
                    break;
                case "prodname":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdName).ToList();
                        break;
                    }
                    else 
                    {
                        Results = _context.Products.OrderBy(x => x.ProdName).ToList();
                        break;
                    }  
                case "prodprice":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdPrice).ToList();
                        break;
                    }
                    else
                    {
                        Results = _context.Products.OrderBy(x => x.ProdPrice).ToList();
                        break;
                    }
                case "prodtype":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdType).ToList();
                        break;
                    }
                    else
                    {
                        Results = _context.Products.OrderBy(x => x.ProdType).ToList();
                        break;
                    }
                default:
                    Results = _context.Products.ToList();
                    break;
            }
            return View(Results);
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct([FromForm]string prodName, [FromForm] decimal prodPrice, [FromForm] string prodType)
        {
            _context.Products.Add(new Product
            {
                ProdName = prodName,
                ProdPrice = prodPrice,
                ProdType = prodType
            });
            _context.SaveChanges();
            return RedirectToAction("ViewProducts",routeValues: new {filterby = "none"});
        }
        public IActionResult DeleteProduct(int? prodId, bool? forceDelete)
        {
            if (forceDelete == true)
            {
                _context.ShoppingCartContents.RemoveRange(_context.ShoppingCartContents.Where(x=>x.ProdId == prodId));
                var productToBeDeleted = _context.Products.FirstOrDefault(x => x.ProdId == prodId);
                _context.Products.Remove(productToBeDeleted);
                _context.SaveChanges();
            }
            else
            {
                var productToBeDeleted = _context.Products.FirstOrDefault(x => x.ProdId == prodId);
                _context.Products.Remove(productToBeDeleted);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewProducts", routeValues: new { filterby = "none" });
        }

        [HttpGet]
        public IActionResult GetDeleteModal(int? prodId)
        {
            if (_context.ShoppingCartContents.Any(x=>x.ProdId == prodId))
            {
                return PartialView("_DeleteModal", _context.Products.FirstOrDefault(x=>x.ProdId == prodId));
            }
            return RedirectToAction("DeleteProduct", routeValues: new { prodId = prodId, forceDelete = "true"});
        }

        public IActionResult ViewDetails(int? prodId)
        {
            var product = _context.Products.FirstOrDefault(x=>x.ProdId == prodId);
            return PartialView("_ViewDetails", product);
        }
    }
}
