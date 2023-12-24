using Microsoft.EntityFrameworkCore;
using userMicroservice.Data;
using userMicroservice.Data.Repository;
using userMicroservice.Services;
using userMicroservice.Services.Interface;

namespace userMicroservice.IoC.IoCApplication
{
    public static class IoCApplication
    {

        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContextClass>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }
    }
}
