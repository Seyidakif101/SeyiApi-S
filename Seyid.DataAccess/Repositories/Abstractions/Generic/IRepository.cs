using Seyid.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Seyid.DataAccess.Repositories.Abstractions.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
