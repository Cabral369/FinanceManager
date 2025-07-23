
using financeManager.Domain.Entities;

namespace financeManager.Application.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}