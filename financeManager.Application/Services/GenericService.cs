using financeManager.Application.DTOs;
using financeManager.Application.Interfaces;

namespace financeManager.Application.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    protected readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<OperationResult<T>> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public virtual async Task<OperationResult<IEnumerable<T>>> GetAllAsync() => await _repository.GetAllAsync();

    public virtual async Task<OperationResult<T>> AddAsync(T entity) => await _repository.AddAsync(entity);

    public virtual async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

    public virtual async Task DeleteAsync(T entity) => await _repository.DeleteAsync(entity);
}