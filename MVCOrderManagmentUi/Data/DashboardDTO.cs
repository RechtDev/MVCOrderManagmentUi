using MVCOrderManagmentUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Data
{
    public class DashboardDTO
    {
        //public List<Product> Products { get; set; }
        //public List<ShoppingCart> ShoppingCarts { get; set; }
        //public List<ShoppingCartContent> ShoppingCartContents { get; set; }
        public decimal PotentialSales { get; set; }
        public int ActiveCarts { get; set; }
        public int ItemsInCarts { get; set; }
    }
}
