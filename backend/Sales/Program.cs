using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.Extensions.Configuration; 
using Sales; 

var builder = WebApplication.CreateBuilder(args); 
// example connection string 

string connectionString = "Server=tcp:localhost;Database=GroceryStoreTest;User Id=SA;Password=MyStrongPass123;TrustServerCertificate=True;"; 

// registering repository with the connection string. 
builder.Services.AddScoped<ISaleRepository>(sp => new SaleRepository(connectionString)); 

// register the engine layer (business logic) 
builder.Services.AddScoped<ISaleEngine, SaleEngine>(); 

// adding controllers (API layer)
 builder.Services.AddControllers(); var app = builder.Build(); 

 // Configure the HTTP request pipeline 
 app.MapControllers();
 
 // Run the application 
 app.Run();