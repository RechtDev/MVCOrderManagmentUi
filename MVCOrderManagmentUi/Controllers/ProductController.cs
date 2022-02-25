using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCOrderManagmentUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCOrderManagmentUi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVCOrderManagmentUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly GSparkShopDBContext _context;
        public ProductController(GSparkShopDBContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> ViewProducts()
        //{
        //    var tickets = await _context.Products.ToListAsync();
        //    return View(tickets);
        //}

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

        public PartialViewResult SearchProducts(string SearchProducts)
        {
            List<Product> Products = new List<Product>();
            var result = Products.Where(a => a.ProdName.ToLower().Contains(SearchProducts)).ToList();
            return PartialView("_GridSearchView", result);
        }

        //public List<Product> ViewProducts()
        //{
        //    List<Product> products = new List<Product>();
        //    foreach (var item in products)
        //    {
        //    }
        //    return products;
        //}
        [HttpGet]
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

        //public ActionResult SearchForm()
        //{
        //    return View("SearchForm");
        //}

        //public ActionResult SearchForName(string searchForNames, bool? des)
        //{
        //    List<Product> searchResults = new List<Product>();
        //    switch (searchForNames)
        //    {
        //        case "none":
        //            searchResults = _context.Products.ToList();
        //            break;
        //        case "prodname":
        //            if (des == true)
        //            {
        //                searchResults = _context.Products.OrderByDescending(x => x.ProdName).ToList();
        //                break;
        //            }
        //            else
        //            {
        //                searchResults = _context.Products.OrderBy(x => x.ProdName).ToList();
        //                break;
        //            }
        //        case "prodprice":
        //            if (des == true)
        //            {
        //                searchResults = _context.Products.OrderByDescending(x => x.ProdPrice).ToList();
        //                break;
        //            }
        //            else
        //            {
        //                searchResults = _context.Products.OrderBy(x => x.ProdPrice).ToList();
        //                break;
        //            }
        //        case "prodtype":
        //            if (des == true)
        //            {
        //                searchResults = _context.Products.OrderByDescending(x => x.ProdType).ToList();
        //                break;
        //            }
        //            else
        //            {
        //                searchResults = _context.Products.OrderBy(x => x.ProdType).ToList();
        //                break;
        //            }
        //        default:
        //            searchResults = _context.Products.ToList();
        //            break;
        //    }
        //    return View(searchResults);
        //}

        //public ViewResult Index()
        //{
        //    var search = new SearchData(TempData);
        //    search.Clear();

        //    return View();
        //}

        //[HttpPost]
        //public RedirectToActionResult Search(SearchView vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var search = new SearchData(TempData)
        //        {
        //            SearchTerm = vm.SearchTerm,
        //            Type = vm.Type
        //        };
        //        return RedirectToAction("Search");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //public ViewResult Search()
        //{
        //    var search = new SearchData(TempData);

        //    if (search.HasSearchTerm)
        //    {
        //        var vm = new SearchView
        //        {
        //            SearchTerm = search.SearchTerm
        //        };

        //        var options = new QueryOptions<Product>
        //        {
        //            Includes = "ProdName, Product.ProdPrice"
        //        };
        //        if (search.IsName)
        //        {
        //            options.Where = b => b.ProdName.Contains(vm.SearchTerm);
        //            vm.Header = $"Search results for book title '{vm.SearchTerm}'";
        //        }
                //if (search.IsPrice)
                //{
                //    int index = vm.SearchTerm.LastIndexOf(' ');
                //    if (index == -1)
                //    {
                //        options.Where = b => b.BookAuthors.Any(
                //            ba => ba.Author.FirstName.Contains(vm.SearchTerm) ||
                //            ba.Author.LastName.Contains(vm.SearchTerm));
                //    }
                //    else
                //    {
                //        string first = vm.SearchTerm.Substring(0, index);
                //        string last = vm.SearchTerm.Substring(index + 1);
                //        options.Where = b => b.BookAuthors.Any(
                //            ba => ba.Author.FirstName.Contains(first) &&
                //            ba.Author.LastName.Contains(last));
                //    }
                //    vm.Header = $"Search results for author '{vm.SearchTerm}'";
                //}
        //        if (search.IsPrice)
        //        {
        //            options.Where = b => b.ProdType.Contains(vm.SearchTerm);
        //            vm.Header = $"Search results for genre ID '{vm.SearchTerm}'";
        //        }
        //        vm.Products = data.Books.List(options);
        //        return View("SearchResults", vm);
        //    }
        //    else
        //    {
        //        //return View("Index");
        //    }
        //}
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
