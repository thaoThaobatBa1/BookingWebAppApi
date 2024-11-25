using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class PaymentMethod
    {
        public Guid PaymentMethodID { get; set; }
        public string MethodName { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
