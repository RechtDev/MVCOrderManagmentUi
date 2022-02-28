using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCOrderManagmentUi.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        [Required]
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdType { get; set; }
    }
}
