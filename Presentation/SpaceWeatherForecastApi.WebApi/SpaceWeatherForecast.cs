﻿namespace SpaceWeatherApi.Models;

public class SpaceWeatherForecast
{
    public string AstronomicalObjectName { get; set; }
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
