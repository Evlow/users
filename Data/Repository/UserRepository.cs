using Microsoft.EntityFrameworkCore;
using userMicroservice.Model;

namespace userMicroservice.Data.Repository
{
    public class UserRepository
    {
        private readonly DbContextClass _contextClass;
        public UserRepository(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        public async Task<List<User>> GetUsersAsync()
        {

            var elements = await _contextClass.Users.ToListAsync().ConfigureAwait(false);

            return elements;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var element = await _contextClass.Users.FirstOrDefaultAsync(user => user.UserId == userId).ConfigureAwait(false);

            return element;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var elementAdded = await _contextClass.Users.AddAsync(user).ConfigureAwait(false);

            await _contextClass.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var elementUpdated = _contextClass.Users.Update(user);

            await _contextClass.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            var elementDeleted = _contextClass.Users.Remove(user);

            await _contextClass.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;

        }
    }
}
