using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Category
    {
        public Guid CategoryID { get; set; }    
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
