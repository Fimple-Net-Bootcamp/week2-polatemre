using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Application.DTOs.AstronomicalObject
{
    public class ListAstronomicalObject
    {
        public int TotalAstronomicalObjectCount { get; set; }
        public object AstronomicalObjects { get; set; }
    }
}
