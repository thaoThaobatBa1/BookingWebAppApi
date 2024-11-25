using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IBanerSevice
    {
        Task<IEnumerable<Baner>> GetAllAsync();
        Task<Baner> GetByIdAsync(Guid id);
        Task AddAsync(Baner Baner);
        Task UpdateAsync(Baner Baner);
        Task DeleteAsync(Guid id);
    }
}
