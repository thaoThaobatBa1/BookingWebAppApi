using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.Sevices
{
    public class BookingTransactionService : IBookingTransactionService
    {
        private readonly IRepository<BookingTransaction> _bookingTransactionRepository;

        public BookingTransactionService(IRepository<BookingTransaction> bookingTransactionRepository)
        {
            _bookingTransactionRepository = bookingTransactionRepository;
        }

        public async Task<IEnumerable<BookingTransaction>> GetAllBookingTransactionsAsync()
        {
            return await _bookingTransactionRepository.GetAllAsync();
        }

        public async Task<BookingTransaction> GetBookingTransactionByIdAsync(Guid id)
        {
            return await _bookingTransactionRepository.GetByIdAsync(id);
        }

        public async Task AddBookingTransactionAsync(BookingTransaction bookingTransaction)
        {
            await _bookingTransactionRepository.AddAsync(bookingTransaction);
        }

        public async Task UpdateBookingTransactionAsync(BookingTransaction bookingTransaction)
        {
            await _bookingTransactionRepository.UpdateAsync(bookingTransaction);
        }

        public async Task DeleteBookingTransactionAsync(Guid id)
        {
            await _bookingTransactionRepository.DeleteAsync(id);
        }
    }

}
