using userMicroservice.Data;
using userMicroservice.Data.Repository;
using userMicroservice.Model;
using userMicroservice.Services.Interface;

namespace userMicroservice.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _userRepository.GetUsersAsync().ConfigureAwait(false);
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
        public async Task<User> CreateUserAsync(User user)
        {
            var userAdded = await _userRepository.CreateUserAsync(user);

            return userAdded;
        }
        public async Task<User> UpdateUserAsync(User user, int userId)
        {
            var userGet = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);
            if (userGet == null)
                throw new Exception($"L'utilisateur avec cet identifiant {userId} n'existe pas");
            userGet.UserName = user.UserName;
            userGet.Address = user.Address;

            await _userRepository.UpdateUserAsync(userGet).ConfigureAwait(false);

            return userGet;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var userGet = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);

            if (userGet == null)
                throw new Exception($"L'utilisateur avec cet identifiant {userId} n'existe pas");

            var userDeleted = await _userRepository.DeleteUserAsync(userGet).ConfigureAwait(false);

            return userDeleted;
        }
    }
}
