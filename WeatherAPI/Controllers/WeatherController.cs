using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherController(WeatherContext context)
        {
            _context = context;
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<Weather>> GetWeather(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City cannot be empty.");
            }

            var weather = await _context.Weather
                .FirstOrDefaultAsync(w => w.City.ToLower() == city.ToLower());

            if (weather == null)
            {
                return NotFound($"Weather information for '{city}' was not found.");
            }

            return Ok(weather);
        }
    }
}