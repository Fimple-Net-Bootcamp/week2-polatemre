using Microsoft.AspNetCore.Mvc;
using SpaceWeatherApi.Models;

namespace SpaceWeatherForecastApi.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpaceWeatherForecastsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SpaceWeatherForecast> Get([FromQuery] int astronomicalObjectId)
        {
            return Enumerable.Range(1, 5).Select(index => new SpaceWeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
