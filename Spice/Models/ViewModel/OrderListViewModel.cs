using System.Collections.Generic;

namespace Spice.Models.ViewModel
{
    public class OrderListViewModel
    {
        public List<OrderDetailViewModel> Orders { get; set; }
        public pagingInfo pagingInfo { get; set; }
    }
}
