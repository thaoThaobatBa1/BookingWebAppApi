using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
