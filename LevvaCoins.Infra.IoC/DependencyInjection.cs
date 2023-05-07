using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.MapperProfiles;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using LevvaCoins.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MysqlDbContext>(opt =>
            {
                opt.UseMySQL(configuration.GetConnectionString("DefaultConection")!);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddAutoMapper(typeof(AccountProfile));
        }
    }
}
