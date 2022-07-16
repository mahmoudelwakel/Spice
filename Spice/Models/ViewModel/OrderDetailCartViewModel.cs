using System.Collections.Generic;

namespace Spice.Models.ViewModel
{
    public class OrderDetailCartViewModel
    {
     public   List<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
