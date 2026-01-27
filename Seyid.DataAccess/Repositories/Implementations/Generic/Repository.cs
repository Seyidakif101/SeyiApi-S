using Microsoft.EntityFrameworkCore;
using Seyid.Core.Entities.Common;
using Seyid.DataAccess.Contexts;
using Seyid.DataAccess.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Seyid.DataAccess.Repositories.Implementations.Generic
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var result =await _context.Set<T>().AnyAsync(expression);
            return result;
        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var result =await _context.Set<T>().FindAsync(id);
            return result;

        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
