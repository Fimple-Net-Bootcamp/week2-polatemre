using Microsoft.Extensions.DependencyInjection;

namespace SpaceWeatherForecastApi.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration)));
    }
}
