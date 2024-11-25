using BookingShop.Model.Model;

namespace BookingAppApi.Model
{
    public class BookingModel
    {
        public short NumberOfGuests { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OderId { get; set; }
        public Guid TableId { get; set; }

    }
}
