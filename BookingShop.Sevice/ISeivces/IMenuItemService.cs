using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(Guid id);
        Task AddMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(Guid id);
    }

}
