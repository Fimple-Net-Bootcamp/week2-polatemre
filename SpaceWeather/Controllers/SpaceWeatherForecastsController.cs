using Microsoft.AspNetCore.Mvc;
using SpaceWeatherApi.Models;

namespace SpaceWeatherApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SpaceWeatherForecastsController : ControllerBase
{
    private readonly ILogger<SpaceWeatherForecastsController> _logger;

    public SpaceWeatherForecastsController(ILogger<SpaceWeatherForecastsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<SpaceWeatherForecast> GetAll([FromQuery] int astronimicalObjectId)
    {
        return Enumerable.Range(1, 5).Select(index => new SpaceWeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55)
        })
        .ToArray();
    }
}
