using System;
using System.Collections.Generic;

#nullable disable

namespace MVCOrderManagmentUi.Models
{
    public partial class ShoppingCartContent
    {
        public int? ProdId { get; set; }
        public int? ShoppingCartId { get; set; }

        public virtual Product Prod { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
