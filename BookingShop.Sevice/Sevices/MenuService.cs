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
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _menuRepository.GetAllAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(Guid id)
        {
            return await _menuRepository.GetByIdAsync(id);
        }

        public async Task AddMenuAsync(Menu menu)
        {
            await _menuRepository.AddAsync(menu);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            await _menuRepository.UpdateAsync(menu);
        }

        public async Task DeleteMenuAsync(Guid id)
        {
            await _menuRepository.DeleteAsync(id);
        }
    }

}
