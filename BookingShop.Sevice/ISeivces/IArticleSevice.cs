using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IArticleSevice
    {
        Task<IEnumerable<article>> GetAllAsync();
        Task<article> GetByIdAsync(Guid id);
        Task AddAsync(article at);
        Task UpdateAsync(article at);
        Task DeleteAsync(Guid id);
    }
}
