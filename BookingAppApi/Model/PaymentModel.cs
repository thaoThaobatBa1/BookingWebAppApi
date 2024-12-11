using BookingShop.Model.Model;

namespace BookingAppApi.Model
{
    public class PaymentModel
    {

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public Guid OrderID { get; set; }
        public Guid PaymentMethodID { get; set; }
    }
}
