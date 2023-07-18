using LevvaCoins.Infra.Data.Configuration;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data
{
    public class LevvaCoinsDbContext : DbContext, IContext
    {
        public LevvaCoinsDbContext(DbContextOptions<LevvaCoinsDbContext> options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
        }
    }
}
