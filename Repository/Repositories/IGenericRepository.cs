using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Response<T>> AddAsync(T entity);
        Task<Response<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities);
        Task<Response<bool>> AnyAsync(Expression<Func<T, bool>> expression);
        Task<Response<T>> GetByIdAsync(int id);
        Task<Response<IEnumerable<T>>> GetAllAsync();
        Task<Response<bool>> RemoveAsync(T entity);
        Task<Response<bool>> RemoveRangeAsync(IEnumerable<T> entities);
        Task<Response<bool>> UpdateAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

    }
}
