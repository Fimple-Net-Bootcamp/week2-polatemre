using SpaceWeatherForecastApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceWeatherForecastApi.Application.Repositories;
using SpaceWeatherForecastApi.Persistence.Repositories;
using SpaceWeatherForecastApi.Application.Abstractions.Services;
using SpaceWeatherForecastApi.Persistence.Services;

namespace SpaceWeatherForecastApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SpaceWeatherForecastApiDbContext>(option => option.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IAstronomicalObjectReadRepository, AstronomicalObjectReadRepository>();
            services.AddScoped<IAstronomicalObjectWriteRepository, AstronomicalObjectWriteRepository>();

            services.AddScoped<IAstronomicalObjectService, AstronomicalObjectService>();
        }
    }
}
