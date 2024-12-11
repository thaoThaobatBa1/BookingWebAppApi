using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class MenuItem
    {
        public Guid MenuItemID { get; set; }

        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public bool Available { get; set; }
        public string? ImageMenuItem { get; set; }
        public int Quantity { get; set; } = 0;
        public int InventoryQuantity { get; set; }


        public Guid? MenuID { get; set; }
        public Menu Menu { get; set; }


        public Guid? CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
