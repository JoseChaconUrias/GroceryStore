using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using User;

var builder = WebApplication.CreateBuilder(args);


// example connection string 
string connectionString = "Server=tcp:localhost;Database=master;User Id=SA;Password=MyStrongPass123;TrustServerCertificate=True;";

// registering  repository with the connection string.
builder.Services.AddScoped<IUserRepository>(sp =>
  new UserRepository(connectionString));

// registering accessor, which depends on the repository.
builder.Services.AddScoped<IUserAccessor, UserAccessor>();

// register the engine layer (business logic)
builder.Services.AddScoped<IUserEngine, UserEngine>();

// registering the manager layer (coordinates the logic)
builder.Services.AddScoped<IUserManager, UserManager>();

// adding controllers (API layer)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

// Run the application
app.Run();
