using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCOrderManagmentUi.Models
{
    public partial class ShoppingCartContent
    {
        [Key]
        public int ShoppingCartContentID { get; set; }
        public int? ProdId { get; set; }
        public int? ShoppingCartId { get; set; }

        public virtual Product Prod { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
