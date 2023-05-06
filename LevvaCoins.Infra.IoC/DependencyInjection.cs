using LevvaCoins.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MysqlDbContext>(opt =>
            {
                opt.UseMySQL(configuration.GetConnectionString("DefaultConection")!);
            });

            return services;
        }
    }
}
