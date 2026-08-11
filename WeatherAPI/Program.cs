using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WeatherDatabase")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();