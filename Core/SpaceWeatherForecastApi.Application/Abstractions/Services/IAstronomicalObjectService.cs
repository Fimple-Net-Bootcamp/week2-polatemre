using SpaceWeatherForecastApi.Application.DTOs.AstronomicalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Application.Abstractions.Services
{
    public interface IAstronomicalObjectService
    {
        Task CreateAstronomicalObjectAsync(CreateAstronomicalObject createAstronomicalObject);
        Task<ListAstronomicalObject> GetAllAstronomicalObjectsAsync(int page, int size);
        Task<SingleAstronomicalObject> GetAstronomicalObjectByIdAsync(int id);
    }
}
