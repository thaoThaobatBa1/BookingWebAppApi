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
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
