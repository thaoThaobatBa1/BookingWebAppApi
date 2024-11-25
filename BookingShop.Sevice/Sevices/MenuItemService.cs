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
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository<MenuItem> _menuItemRepository;

        public MenuItemService(IRepository<MenuItem> menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(Guid id)
        {
            return await _menuItemRepository.GetByIdAsync(id);
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.AddAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.UpdateAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(Guid id)
        {
            await _menuItemRepository.DeleteAsync(id);
        }
    }

}
