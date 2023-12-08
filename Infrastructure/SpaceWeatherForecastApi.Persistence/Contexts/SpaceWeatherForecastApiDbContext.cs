using SpaceWeatherForecastApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using SpaceWeatherForecastApi.Domain.Entities;

namespace SpaceWeatherForecastApi.Persistence.Contexts
{
    public class SpaceWeatherForecastApiDbContext : DbContext
    {
        public SpaceWeatherForecastApiDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<AstronimicalObject> AstronimicalObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<AstronimicalObject>()
            //    .HasKey(b => b.Id);

            //builder.Entity<AstronimicalObject>()
            //    .HasIndex(o => o.OrderCode)
            //    .IsUnique();

            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan property'dir.Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
