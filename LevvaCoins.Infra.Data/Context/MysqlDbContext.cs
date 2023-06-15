using LevvaCoins.Infra.Data.Interface;
using LevvaCoins.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Context
{
    public class MysqlDbContext: DbContext, IContext
    {
        public MysqlDbContext(DbContextOptions<MysqlDbContext> options):base(options)
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
