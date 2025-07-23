using financeManager.Application.DTOs;

namespace financeManager.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<OperationResult<T>> GetByIdAsync(int id);
    Task<OperationResult<IEnumerable<T>>> GetAllAsync();
    Task<OperationResult<T>> AddAsync(T entity);
    Task<OperationResultNoData> UpdateAsync(T entity);
    Task<OperationResultNoData> DeleteAsync(T entity);
}