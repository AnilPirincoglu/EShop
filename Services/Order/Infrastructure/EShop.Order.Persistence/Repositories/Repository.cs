using EShop.Order.Application.Interfaces;
using EShop.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Persistence.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().SingleOrDefaultAsync(filter);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
