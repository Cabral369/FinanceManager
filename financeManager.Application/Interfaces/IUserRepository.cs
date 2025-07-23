using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using financeManager.Domain.Entities;

namespace financeManager.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}