using System.Reflection;
using LevvaCoins.Domain.SeedWork.Notification;
using LevvaCoins.Infra.Data.Configuration;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data
{
    public sealed class LevvaCoinsDbContext : DbContext, IContext
    {
        public LevvaCoinsDbContext(DbContextOptions<LevvaCoinsDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;

        }
        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            var propertyNames = typeof(Notifiable)
                .GetProperties()
                .Select(p => p.Name)
                .ToList();

            var entityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(t => typeof(Notifiable)
                    .IsAssignableFrom(t.ClrType));

            foreach (var entityType in entityTypes)
            {
                var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);

                foreach (var propertyName in propertyNames)
                    entityTypeBuilder.Ignore(propertyName);
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
