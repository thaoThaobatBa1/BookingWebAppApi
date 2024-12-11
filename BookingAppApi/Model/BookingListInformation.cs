namespace BookingAppApi.Model
{
    public class BookingListInformation
    {
        public Guid OrderID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public short NumberOfGuests { get; set; }
        public string NameOfGuest { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Deposit {  get; set; }
        public string StatusName { get; set; }

    }
}
