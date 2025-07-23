using System.Linq.Expressions;
using financeManager.Application.DTOs;

namespace financeManager.Application.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<OperationResult<T>> GetByIdAsync(int id);
    Task<OperationResult<IEnumerable<T>>> GetAllAsync();
    Task<OperationResult<T>> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}