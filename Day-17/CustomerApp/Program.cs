var builder = WebApplication.CreateBuilder(args);

// Add controller support
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();