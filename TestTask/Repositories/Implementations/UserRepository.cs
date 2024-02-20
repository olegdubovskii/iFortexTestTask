using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetUsersByActivityStatusAsync(UserStatus activityStatus)
        {
            return await _dbSet.Where(user => user.Status == activityStatus)
                .ToListAsync();
        }

        public async Task<User> GetUserWithMaxOrdersQuantityAsync()
        {
            return await _dbSet.Include(user => user.Orders)
                .OrderByDescending(user => user.Orders.Count)
                .FirstOrDefaultAsync();
        }
    }
}
