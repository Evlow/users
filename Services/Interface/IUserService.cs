using userMicroservice.Model;

namespace userMicroservice.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetUserList();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user, int userId);
        Task<User> DeleteUserAsync(int userId);
    }
}
