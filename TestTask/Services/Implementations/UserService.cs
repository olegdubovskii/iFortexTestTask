using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUser()
        {
            return await _userRepository.GetUserWithMaxOrdersQuantityAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsersByActivityStatusAsync(UserStatus.Inactive);
        }
    }
}
