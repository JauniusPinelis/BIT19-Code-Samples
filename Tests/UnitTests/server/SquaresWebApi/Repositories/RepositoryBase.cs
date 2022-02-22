using Microsoft.EntityFrameworkCore;
using SquaresWebApi.Data;
using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School_WebAPI_BE.Repositories
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int entityId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task<int> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(List<T> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public void PrepareCreateRange(List<T> entities)
        {
            _context.AddRange(entities);
        }

        public void PrepareRemoveRange(List<T> entities)
        {
            _context.RemoveRange(entities);
        }
    }
}