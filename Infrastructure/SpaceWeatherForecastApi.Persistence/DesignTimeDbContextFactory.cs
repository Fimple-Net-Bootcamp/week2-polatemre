using SpaceWeatherForecastApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SpaceWeatherForecastApiDbContext>
    {
        public SpaceWeatherForecastApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SpaceWeatherForecastApiDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}
