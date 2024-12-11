using BookingShop.Model.Model;

namespace BookingAppApi.Model
{
    public class OrderDetailModel
    {
        public int Quantity { get; set; }
        
        public Guid MenuItemID { get; set; }
        public Guid OrderID { get; set; }
    }
}
