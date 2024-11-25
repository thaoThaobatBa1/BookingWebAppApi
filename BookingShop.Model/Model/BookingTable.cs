using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class BookingTable
    {
        public Guid BookingTableId { get; set; }

        public Guid BookingID { get; set; }
        public Booking Booking { get; set; }

        public Guid TableID { get; set; }
        public Table Table { get; set; }
    }
}
