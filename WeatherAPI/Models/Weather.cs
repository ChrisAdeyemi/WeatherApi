using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Current weather condition is required.")]
        [RegularExpression(
            "^(sunny|cloudy|overcast|rain|drizzle|fog|snow)$",
            ErrorMessage = "Invalid weather condition.")]
        public string CurrentCondition { get; set; } = string.Empty;

        [Range(-40, 40, ErrorMessage = "Maximum temperature must be between -40 and 40 Celsius.")]
        public int MaxTemperature { get; set; }

        [Range(-40, 40, ErrorMessage = "Minimum temperature must be between -40 and 40 Celsius.")]
        public int MinTemperature { get; set; }

        [Required(ErrorMessage = "Wind direction is required.")]
        [RegularExpression(
            "^(north|south|east|west|northeast|southeast|northwest|southwest)$",
            ErrorMessage = "Invalid wind direction.")]
        public string WindDirection { get; set; } = string.Empty;

        [Range(0, 200, ErrorMessage = "Wind speed must be between 0 and 200 km/h.")]
        public int WindSpeed { get; set; }

        [Required(ErrorMessage = "Next day outlook is required.")]
        [RegularExpression(
            "^(sunny|cloudy|overcast|rain|drizzle|fog|snow)$",
            ErrorMessage = "Invalid weather outlook.")]
        public string NextDayOutlook { get; set; } = string.Empty;
    }
}