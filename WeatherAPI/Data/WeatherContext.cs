using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Weather>().HasData(
                new Weather
                {
                    Id = 1,
                    City = "Dublin",
                    CurrentCondition = "cloudy",
                    MaxTemperature = 18,
                    MinTemperature = 11,
                    WindDirection = "southwest",
                    WindSpeed = 25,
                    NextDayOutlook = "rain"
                },

                new Weather
                {
                    Id = 2,
                    City = "London",
                    CurrentCondition = "rain",
                    MaxTemperature = 16,
                    MinTemperature = 9,
                    WindDirection = "west",
                    WindSpeed = 30,
                    NextDayOutlook = "cloudy"
                },

                new Weather
                {
                    Id = 3,
                    City = "Paris",
                    CurrentCondition = "sunny",
                    MaxTemperature = 23,
                    MinTemperature = 14,
                    WindDirection = "south",
                    WindSpeed = 15,
                    NextDayOutlook = "cloudy"
                },

                new Weather
                {
                    Id = 4,
                    City = "New York",
                    CurrentCondition = "sunny",
                    MaxTemperature = 28,
                    MinTemperature = 20,
                    WindDirection = "east",
                    WindSpeed = 18,
                    NextDayOutlook = "overcast"
                },

                new Weather
                {
                    Id = 5,
                    City = "Sydney",
                    CurrentCondition = "cloudy",
                    MaxTemperature = 21,
                    MinTemperature = 15,
                    WindDirection = "southeast",
                    WindSpeed = 20,
                    NextDayOutlook = "sunny"
                },

                new Weather
                {
                    Id = 6,
                    City = "Tokyo",
                    CurrentCondition = "rain",
                    MaxTemperature = 24,
                    MinTemperature = 18,
                    WindDirection = "northeast",
                    WindSpeed = 22,
                    NextDayOutlook = "drizzle"
                }
            );
        }
    }
}