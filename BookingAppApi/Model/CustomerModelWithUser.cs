namespace BookingAppApi.Model
{
    public class CustomerModelWithUser
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
