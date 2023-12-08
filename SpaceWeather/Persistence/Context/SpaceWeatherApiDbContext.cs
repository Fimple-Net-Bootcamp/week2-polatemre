using Microsoft.EntityFrameworkCore;
using SpaceWeatherApi.Entities;
using System.Collections.Generic;

namespace SpaceWeatherApi.Persistence.Context
{
    public class SpaceWeatherApiDbContext: DbContext
    {
        public DbSet<AstronimicalObject> AstronimicalObjects { get; set; }

        //public string DbPath { get; }

        //public SpaceWeatherApiDbContext()
        //{
        //    var folder = Environment.SpecialFolder.LocalApplicationData;
        //    var path = Environment.GetFolderPath(folder);
        //    DbPath = System.IO.Path.Join(path, "SpaceWeather.db");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SpaceWeather.db");
        }
    }
}
