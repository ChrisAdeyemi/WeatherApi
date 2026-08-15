using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Railway provides PORT.
// Locally, use port 8080.
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Database connection
string connectionString;

if (builder.Environment.IsDevelopment())
{
    // Local PostgreSQL connection
    connectionString =
        builder.Configuration.GetConnectionString("WeatherDatabase")
        ?? throw new InvalidOperationException(
            "Local PostgreSQL connection string not found.");
}
else
{
    // Railway PostgreSQL connection
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

// OpenAPI document
app.MapOpenApi();

// Swagger UI
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "WeatherAPI v1");
});

// API controllers
app.MapControllers();

app.Run();