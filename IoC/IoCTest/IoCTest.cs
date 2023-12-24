using Microsoft.EntityFrameworkCore;
using userMicroservice.Data;

namespace userMicroservice.IoC.IoCTest
{
    public static class IoCTest
    {
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<DbContextClass>(options =>
                options.UseInMemoryDatabase(databaseName: "TestApplication")
            );

            return services;
        }
    }
}
