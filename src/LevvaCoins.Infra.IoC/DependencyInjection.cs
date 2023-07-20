using System.Reflection;
using System.Text;
using LevvaCoins.Application.MapperProfiles;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data;
using LevvaCoins.Infra.Data.Interface;
using LevvaCoins.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        private const string CORS_POLICY = "AllowLevvaCoinsOrigin";
        private const string ALLOWED_ORIGIN = "http://localhost:5173";

        public static void AddLevvaCoinsService(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey")!);
            services.AddDbContext<IContext, LevvaCoinsDbContext>(opt =>
            {
                opt.UseSqlite(
                    configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly(typeof(LevvaCoinsDbContext).Assembly.FullName)
                );
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
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
            services.AddCors(opt => opt.AddPolicy(CORS_POLICY, opt => opt.WithOrigins(ALLOWED_ORIGIN).AllowAnyMethod().AllowAnyHeader()));
        }
    }
}
