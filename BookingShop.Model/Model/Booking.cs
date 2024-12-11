using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Booking
    {
        public Guid BookingID { get; set; }
        public DateTime BookingDate { get; set; }   
        public TimeSpan ReservationTime { get; set; }
        public short NumberOfGuests { get; set; }
        public decimal Price { get; set; }

        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<BookingTable> BookingTables { get; set; }
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
    }
}
