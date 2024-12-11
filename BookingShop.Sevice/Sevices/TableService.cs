using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.Sevices
{
    public class TableService : ITableSevice
    {
        private readonly IRepository<Table> _tableRepository;

        public TableService(IRepository<Table> tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        public async Task<Table> GetTableByIdAsync(Guid id)
        {
            return await _tableRepository.GetByIdAsync(id);
        }

        public async Task AddTableAsync(Table table)
        {
            await _tableRepository.AddAsync(table);
        }

        public async Task UpdateTableAsync(Table table)
        {
            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteTableAsync(Guid id)
        {
            await _tableRepository.DeleteAsync(id);
        }

      
    }
}
