using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers();

builder.Services.AddOpenApi();

string connectionString;

if (builder.Environment.IsDevelopment())
{
    connectionString =
        builder.Configuration.GetConnectionString("WeatherDatabase")
        ?? throw new InvalidOperationException(
            "Local PostgreSQL connection string not found.");
}
else
{
    connectionString =
        $"Host={Environment.GetEnvironmentVariable("PGHOST")};" +
        $"Port={Environment.GetEnvironmentVariable("PGPORT")};" +
        $"Database={Environment.GetEnvironmentVariable("PGDATABASE")};" +
        $"Username={Environment.GetEnvironmentVariable("PGUSER")};" +
        $"Password={Environment.GetEnvironmentVariable("PGPASSWORD")};";
}

builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "WeatherAPI v1");
});

app.MapControllers();

app.Run();