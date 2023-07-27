using System.Reflection;
using System.Text;
using LevvaCoins.Application.MapperProfiles;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddLevvaCoinsService(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey")!);
        services.AddDbContext<IContext, LevvaCoinsDbContext>(opt =>
        {
            opt.UseSqlite(
                configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly(typeof(LevvaCoinsDbContext).Assembly.FullName)
            );
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.Load("LevvaCoins.Application")));
        services.AddAutoMapper(typeof(DefaultMapper));

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}
