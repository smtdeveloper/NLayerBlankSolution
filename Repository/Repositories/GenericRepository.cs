using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<Response<T>> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new Response<T>(true, "Entity added successfully.", entity);
        }
        catch (Exception ex)
        {
            return new Response<T>(false, $"Error adding entity: {ex.Message}", null);
        }
    }

    public async Task<Response<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return new Response<IEnumerable<T>>(true, "Entities added successfully.", entities);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<T>>(false, $"Error adding entities: {ex.Message}", null);
        }
    }

    public async Task<Response<bool>> AnyAsync(Expression<Func<T, bool>> expression)
    {
        try
        {
            var any = await _dbSet.AnyAsync(expression);
            return new Response<bool>(true, "", any);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, $"Error checking existence: {ex.Message}", false);
        }
    }

    public async Task<Response<T>> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return new Response<T>(false, "Entity not found.", null);

            return new Response<T>(true, "", entity);
        }
        catch (Exception ex)
        {
            return new Response<T>(false, $"Error getting entity: {ex.Message}", null);
        }
    }

    public async Task<Response<IEnumerable<T>>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return new Response<IEnumerable<T>>(true, "", entities);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<T>>(false, $"Error getting entities: {ex.Message}", null);
        }
    }

    public async Task<Response<bool>> RemoveAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new Response<bool>(true, "Entity removed successfully.", true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, $"Error removing entity: {ex.Message}", false);
        }
    }

    public async Task<Response<bool>> RemoveRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return new Response<bool>(true, "Entities removed successfully.", true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, $"Error removing entities: {ex.Message}", false);
        }
    }

    public async Task<Response<bool>> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new Response<bool>(true, "Entity updated successfully.", true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, $"Error updating entity: {ex.Message}", false);
        }
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
}
