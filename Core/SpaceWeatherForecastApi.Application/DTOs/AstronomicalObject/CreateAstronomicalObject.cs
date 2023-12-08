using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Application.DTOs.AstronomicalObject
{
    public class CreateAstronomicalObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Distance { get; set; }
    }
}
