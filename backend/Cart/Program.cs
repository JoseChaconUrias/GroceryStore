using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Cart;

var builder = WebApplication.CreateBuilder(args);


// example connection string 
string connectionString = "Server=tcp:localhost;Database=master;User Id=SA;Password=MyStrongPass123;TrustServerCertificate=True;";

// registering  repository with the connection string.
builder.Services.AddScoped<ICartRepository>(sp =>
  new ProductRepository(connectionString));

// registering accessor, which depends on the repository.
builder.Services.AddScoped<ICartAccessor, CartAccessor>();

// register the engine layer (business logic)
builder.Services.AddScoped<ICartEngine, CartEngine>();

// registering the manager layer (coordinates the logic)
builder.Services.AddScoped<ICartManager, CartManager>();

// adding controllers (API layer)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

// Run the application
app.Run();