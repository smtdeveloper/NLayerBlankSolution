using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services;

public interface IGenericService<T> where T : class
{
    Task<Response<T>> CreateAsync(T entity);
    Task<Response<IEnumerable<T>>> CreateRangeAsync(IEnumerable<T> entities);
    Task<Response<T>> GetByIdAsync(int id);
    Task<Response<IEnumerable<T>>> GetAllAsync();
    Task<Response<bool>> UpdateAsync(T entity);
    Task<Response<bool>> DeleteAsync(T entity);
    Task<Response<bool>> DeleteRangeAsync(IEnumerable<T> entities);
}
