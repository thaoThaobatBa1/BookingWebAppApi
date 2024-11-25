using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class Payment
    {
        public Guid PaymentID { get; set; }

        public  DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public Guid? OrderID { get; set; }
        public Order Order { get; set; }
        

        public Guid? PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public ICollection<BookingTransaction> BookingTransactions { get; set; }

    }
}
