using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCOrderManagmentUi.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        [Required(ErrorMessage = "Product name required")]
        public string ProdName { get; set; }
        [Required(ErrorMessage = "Product price required")]
        [DataType(DataType.Currency)]
        public decimal ProdPrice { get; set; }
        [Required (ErrorMessage = "Product type required")]
        public string ProdType { get; set; }
    }
}
