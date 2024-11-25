using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookingDbContext _context;
        private readonly DbSet<T> _dbSet;
       
        public Repository()
        {
            _context = new BookingDbContext();
            _dbSet = _context.Set<T>(); 
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            };
        }
        
    }
}
