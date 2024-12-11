using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class OrderDetail
    {
        public Guid OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public Guid MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }
        
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
    }
}
