using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Model
{
    public class BookingTransaction
    {
        [Key]
        public Guid TransactionID { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal TransactionAmount { get; set; }


        public Guid? PaymentID { get; set; }
        public Payment Payments { get; set; }
    }
}
