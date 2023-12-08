using SpaceWeatherForecastApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceWeatherForecastApi.Application.Repositories;
using SpaceWeatherForecastApi.Persistence.Repositories;

namespace SpaceWeatherForecastApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SpaceWeatherForecastApiDbContext>(option => option.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IAstronimicalObjectReadRepository, AstronimicalObjectReadRepository>();
            services.AddScoped<IAstronimicalObjectWriteRepository, AstronimicalObjectWriteRepository>();

            //services.AddScoped<IAstronimicalObjectService, AstronimicalObjectService>();
        }
    }
}
