using userMicroservice.Data;
using userMicroservice.IoC.IoCApplication;
using userMicroservice.IoC.IoCTest;
using userMicroservice.Services;
using userMicroservice.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// if the actual environment running is Test, use the test database which is "InMemory database"
if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.ConfigureDBContextTest();
}
else
{
    builder.Services.ConfigureDBContext(configuration);
}

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }