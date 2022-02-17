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
                PotentialSales = _context.ShoppingCartContents.Include(x => x.Prod).Sum(x => x.Prod.ProdPrice)
            };
            return View(DTO);
        }
        public IActionResult ShowAllShoppingCarts()
        {
            var shoppingCarts = _context.ShoppingCartContents.Include(x => x.ShoppingCart).Include(x => x.Prod).ToList();
            return View(shoppingCarts);
        }
    }
}
