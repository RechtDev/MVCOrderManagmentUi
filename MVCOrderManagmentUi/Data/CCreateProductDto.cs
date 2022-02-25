using MVCOrderManagmentUi.Models;
using System.Collections.Generic;

namespace MVCOrderManagmentUi.Data
{
    public class CreateProductDto
    {
        public Product Product { get; set; }
        public List<string> ProductType { get; set; }
    }
}
