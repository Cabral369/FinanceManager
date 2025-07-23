using financeManager.Application.Interfaces;
using financeManager.Domain.Entities;
using financeManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeManager.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
}
