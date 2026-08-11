using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeatherAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "City", "CurrentCondition", "MaxTemperature", "MinTemperature", "NextDayOutlook", "WindDirection", "WindSpeed" },
                values: new object[,]
                {
                    { 1, "Dublin", "cloudy", 18, 11, "rain", "southwest", 25 },
                    { 2, "London", "rain", 16, 9, "cloudy", "west", 30 },
                    { 3, "Paris", "sunny", 23, 14, "cloudy", "south", 15 },
                    { 4, "New York", "sunny", 28, 20, "overcast", "east", 18 },
                    { 5, "Sydney", "cloudy", 21, 15, "sunny", "southeast", 20 },
                    { 6, "Tokyo", "rain", 24, 18, "drizzle", "northeast", 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
