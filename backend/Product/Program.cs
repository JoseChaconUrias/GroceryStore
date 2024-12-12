using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Product;

var builder = WebApplication.CreateBuilder(args);


// example connection string 
string connectionString = "Server=tcp:localhost;Database=GroceryStoreTest;User Id=SA;Password=MyStrongPass123;TrustServerCertificate=True;";

// registering  repository with the connection string.
builder.Services.AddScoped<IProductRepository>(sp =>
  new ProductRepository(connectionString));

// registering accessor, which depends on the repository.
builder.Services.AddScoped<IProductAccessor, ProductAccessor>();

// register the engine layer (business logic)
builder.Services.AddScoped<IProductEngine, ProductEngine>();

// registering the manager layer (coordinates the logic)
builder.Services.AddScoped<IProductManager, ProductManager>();

// adding controllers (API layer)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

// Run the application
app.Run();