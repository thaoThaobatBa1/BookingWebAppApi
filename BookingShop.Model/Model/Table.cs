using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Table
    {
        public Guid TableID { get; set; }
        public string TableNumber { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }  
        public string Location { get; set; }

        public ICollection<BookingTable> BookingTables { get; set; }

    }
}
