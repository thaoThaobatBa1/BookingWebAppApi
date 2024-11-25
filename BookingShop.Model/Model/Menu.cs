using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Menu
    {
        public Guid MenuID { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
