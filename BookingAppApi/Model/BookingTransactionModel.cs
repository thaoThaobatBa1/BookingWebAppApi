namespace BookingAppApi.Model
{
    public class BookingTransactionModel
    {
        public DateTime TransactionDate { get; set; }

        public decimal TransactionAmount { get; set; }

        public Guid? PaymentID { get; set; }
    }
}
