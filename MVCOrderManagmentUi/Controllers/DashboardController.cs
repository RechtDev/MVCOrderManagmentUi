using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCOrderManagmentUi.Data;
using MVCOrderManagmentUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Controllers
{
    public class DashboardController : Controller
    {
        private readonly GSparkShopDBContext _context;
        private DashboardDTO DTO;
        public DashboardController(GSparkShopDBContext context)
        {
            _context = context;
        }
        public IActionResult ShowDashboard()
        {
            DTO = new DashboardDTO
            {
                ActiveCarts = _context.ShoppingCarts.Count(),
                ItemsInCarts = _context.ShoppingCartContents.Count(),
                PotentialSales = _context.ShoppingCartContents.Include(x => x.Prod).Sum(x => x.Prod.ProdPrice),
                ShoppingCarts = new List<ShoppingCart>()
            };

            var result = _context.ShoppingCartContents.Include(x => x.ShoppingCart).Include(x => x.Prod).ToList();
            DTO.ShoppingCarts = from cart in result
                              group cart by cart.ShoppingCartId;
            var queryResult = _context.ShoppingCartContents.Include(x => x.Prod);
            DTO.MostAddedItemToCart = (from prods in queryResult.AsEnumerable()
                                       group prods by prods.Prod.ProdName).Take(1);
            return View(DTO);
        }
        public IActionResult ShowAllShoppingCarts()
        {
            return View();
        }
    }
}
