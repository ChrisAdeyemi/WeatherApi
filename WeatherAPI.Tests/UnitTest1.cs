using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Controllers;
using WeatherAPI.Data;
using WeatherAPI.Models;

namespace WeatherAPI.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public async Task GetWeather_ReturnsDublinWeather()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: "WeatherTestDatabase")
                .Options;

            using var context = new WeatherContext(options);

            context.Weather.Add(new Weather
            {
                Id = 1,
                City = "Dublin",
                CurrentCondition = "cloudy",
                MaxTemperature = 18,
                MinTemperature = 11,
                WindDirection = "southwest",
                WindSpeed = 25,
                NextDayOutlook = "rain"
            });

            await context.SaveChangesAsync();

            var controller = new WeatherController(context);

            // Act
            var result = await controller.GetWeather("Dublin");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var weather = Assert.IsType<Weather>(okResult.Value);

            Assert.Equal("Dublin", weather.City);
            Assert.Equal("cloudy", weather.CurrentCondition);
            Assert.Equal(18, weather.MaxTemperature);
            Assert.Equal(11, weather.MinTemperature);
        }

        [Fact]
        public async Task GetWeather_UnknownCity_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: "WeatherTestDatabase2")
                .Options;

            using var context = new WeatherContext(options);

            var controller = new WeatherController(context);

            // Act
            var result = await controller.GetWeather("Belfast");

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);

            Assert.Contains("Belfast", notFoundResult.Value?.ToString());
        }

        [Fact]
        public async Task GetWeather_EmptyCity_ReturnsBadRequest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: "WeatherTestDatabase3")
                .Options;

            using var context = new WeatherContext(options);

            var controller = new WeatherController(context);

            // Act
            var result = await controller.GetWeather("");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            Assert.Equal("City cannot be empty.", badRequestResult.Value);
        }
    }
}