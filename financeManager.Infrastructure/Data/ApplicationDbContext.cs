using financeManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace financeManager.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}