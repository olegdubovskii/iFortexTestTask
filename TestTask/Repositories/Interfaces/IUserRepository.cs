using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserWithMaxOrdersQuantityAsync();
        Task<List<User>> GetUsersByActivityStatusAsync(UserStatus activityStatus);
    }
}
