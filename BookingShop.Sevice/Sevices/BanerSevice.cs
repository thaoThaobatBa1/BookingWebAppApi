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
    public class BanerSevice : IBanerSevice
    {
        private readonly IRepository<Baner> _repository;

        public BanerSevice(IRepository<Baner> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Baner Baner)
        {
           await _repository.AddAsync(Baner);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Baner>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Baner> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Baner Baner)
        {
            await _repository.UpdateAsync(Baner);
        }
    }
}
