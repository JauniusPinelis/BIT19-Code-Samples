using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    // Generic Repository pattern
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            // impletent soft delete

            _context.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.LastModified = System.DateTime.Now;

            _context.Update(entity);

            _context.SaveChanges();
        }

        public void Create(T entity)
        {
            entity.Created = System.DateTime.Now;
            entity.LastModified = System.DateTime.Now;

            _context.Add(entity);

            _context.SaveChanges();
        }
    }
}
