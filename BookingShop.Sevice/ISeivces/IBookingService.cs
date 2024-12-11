using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(Guid id);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(Guid id);
    }
}

