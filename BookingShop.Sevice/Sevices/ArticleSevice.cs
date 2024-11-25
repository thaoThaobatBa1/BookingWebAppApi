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
    public class ArticleSevice : IArticleSevice
    {
        private readonly IRepository<article> repository;

        public ArticleSevice(IRepository<article> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(article at)
        {
           await repository.AddAsync(at);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<article>> GetAllAsync()
        {
           return await repository.GetAllAsync();   
        }

        public async Task<article> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(article at)
        {
           await repository.UpdateAsync(at);
        }
    }
}
