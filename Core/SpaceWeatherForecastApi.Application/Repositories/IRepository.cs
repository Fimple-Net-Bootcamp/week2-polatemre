using SpaceWeatherForecastApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace SpaceWeatherForecastApi.Application.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
