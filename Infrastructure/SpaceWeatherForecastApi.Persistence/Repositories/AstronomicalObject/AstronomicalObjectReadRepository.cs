using SpaceWeatherForecastApi.Application.Repositories;
using SpaceWeatherForecastApi.Domain.Entities;
using SpaceWeatherForecastApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Persistence.Repositories
{
    public class AstronomicalObjectReadRepository : ReadRepository<AstronomicalObject>, IAstronomicalObjectReadRepository
    {
        public AstronomicalObjectReadRepository(SpaceWeatherForecastApiDbContext context) : base(context)
        {
        }
    }
}
