using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Railway needs the app to listen on its assigned PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers();

builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WeatherDatabase")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();