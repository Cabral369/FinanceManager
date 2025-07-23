using financeManager.Application.DTOs;
using financeManager.Application.Interfaces;
using financeManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeManager.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<OperationResult<T>> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            return entity is null
                ? OperationResult<T>.Fail("Entity not found")
                : OperationResult<T>.Ok(entity);
        }
        catch (Exception ex)
        {
            return OperationResult<T>.Fail($"Error getting entity: {ex.Message}");
        }
    }

    public async Task<OperationResult<IEnumerable<T>>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return OperationResult<IEnumerable<T>>.Ok(entities);
        }
        catch (Exception ex)
        {
            return OperationResult<IEnumerable<T>>.Fail($"Error getting all entities: {ex.Message}");
        }
    }

    public async Task<OperationResult<T>> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return OperationResult<T>.Ok(entity);
        }
        catch (Exception ex)
        {
            return OperationResult<T>.Fail($"Error adding entity: {ex.Message}");
        }
    }

    public async Task<OperationResultNoData> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return OperationResultNoData.Ok();
        }
        catch (Exception ex)
        {
            return OperationResultNoData.Fail($"Error updating entity: {ex.Message}");
        }
    }

    public async Task<OperationResultNoData> DeleteAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return OperationResultNoData.Ok();
        }
        catch (Exception ex)
        {
            return OperationResultNoData.Fail($"Error deleting entity: {ex.Message}");
        }
    }
}