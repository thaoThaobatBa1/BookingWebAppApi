using BookingShop.Model.Model;

namespace BookingAppApi.Model
{
    public class MenuItemModel
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public int InventoryQuantity { get; set; }

        public Guid MenuID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
