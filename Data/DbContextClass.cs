using Microsoft.EntityFrameworkCore;
using userMicroservice.Model;

namespace userMicroservice.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
