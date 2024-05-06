using Entities.DTOs;
using Repository.Repositories;

namespace Service.Services;
public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<Response<T>> CreateAsync(T entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<Response<IEnumerable<T>>> CreateRangeAsync(IEnumerable<T> entities)
    {
        return await _repository.AddRangeAsync(entities);
    }

    public async Task<Response<T>> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Response<IEnumerable<T>>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Response<bool>> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task<Response<bool>> DeleteAsync(T entity)
    {
        return await _repository.RemoveAsync(entity);
    }

    public async Task<Response<bool>> DeleteRangeAsync(IEnumerable<T> entities)
    {
        return await _repository.RemoveRangeAsync(entities);
    }
}