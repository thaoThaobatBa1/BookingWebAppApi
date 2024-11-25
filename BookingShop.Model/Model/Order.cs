using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice{ get; set; }

        public Guid? PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }


        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
