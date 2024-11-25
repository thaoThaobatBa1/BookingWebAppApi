using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IBookingTransactionService
    {
        Task<IEnumerable<BookingTransaction>> GetAllBookingTransactionsAsync();
        Task<BookingTransaction> GetBookingTransactionByIdAsync(Guid id);
        Task AddBookingTransactionAsync(BookingTransaction bookingTransaction);
        Task UpdateBookingTransactionAsync(BookingTransaction bookingTransaction);
        Task DeleteBookingTransactionAsync(Guid id);
    }

}
