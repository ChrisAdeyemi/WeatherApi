using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers();

var connectionString = builder.Configuration["DATABASE_URL"];

builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();