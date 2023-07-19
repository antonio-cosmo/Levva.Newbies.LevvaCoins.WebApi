using System.Reflection;
using System.Text;
using LevvaCoins.Application.MapperProfiles;
using LevvaCoins.Application.Middlewares;
using LevvaCoins.Application.UseCases.Transactions.Interfaces;
using LevvaCoins.Application.UseCases.Transactions.Services;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data;
using LevvaCoins.Infra.Data.Interface;
using LevvaCoins.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        private const string CORS_POLICY = "AllowLevvaCoinsOrigin";
        private const string ALLOWED_ORIGIN = "http://localhost:5173";

        public static void AddLevvaCoinsService(this IServiceCollection services)
        {
            var secretKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET__KEY")!);
            services.AddDbContext<IContext, LevvaCoinsDbContext>(opt =>
            {
                opt.UseSqlite(
                    $"Data Source={Environment.GetEnvironmentVariable("DATABASE__CONNECTION__URL")}",
                    x => x.MigrationsAssembly(typeof(LevvaCoinsDbContext).Assembly.FullName)
                );
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITransactionServices, TransactionServices>();

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
            services.AddCors(opt =>
            {
                opt.AddPolicy(CORS_POLICY, opt =>
                {
                    opt.WithOrigins(ALLOWED_ORIGIN).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        public static void UseLevvacoinsStartup(this WebApplication app)
        {
            app.UseCors(CORS_POLICY);
            app.UseMiddleware<ExceptionHandlerMidleware>();
            app.UseMiddleware<AuthorizationExceptionHandlerMidleware>();
        }
    }
}
