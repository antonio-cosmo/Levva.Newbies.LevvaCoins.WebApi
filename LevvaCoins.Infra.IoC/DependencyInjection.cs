using System.Reflection;
using System.Text;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Categories.MapperProfiles;
using LevvaCoins.Application.Categories.Services;
using LevvaCoins.Application.Middlewares;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Mapper;
using LevvaCoins.Application.Transactions.Services;
using LevvaCoins.Application.Users.Interfaces;
using LevvaCoins.Application.Users.MapperProfiles;
using LevvaCoins.Application.Users.Services;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
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
            services.AddDbContext<IContext, MysqlDbContext>(opt =>
            {
                opt.UseSqlite(
                    $"Data Source={Environment.GetEnvironmentVariable("DATABASE__CONNECTION__URL")}",
                    x => x.MigrationsAssembly(typeof(MysqlDbContext).Assembly.FullName)
                );
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.Load("LevvaCoins.Application")));
            services.AddAutoMapper(typeof(UserProfile), typeof(CategoryProfile), typeof(TransactionProfile));

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
