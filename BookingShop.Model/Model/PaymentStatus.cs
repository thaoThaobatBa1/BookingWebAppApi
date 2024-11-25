using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class PaymentStatus
    {
        public Guid PaymentStatusID { get; set; }
        public string PaymentStatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
