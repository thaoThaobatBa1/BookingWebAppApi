
using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface ITableSevice
    {
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(Guid id);
        Task AddTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(Guid id);
    }
}
