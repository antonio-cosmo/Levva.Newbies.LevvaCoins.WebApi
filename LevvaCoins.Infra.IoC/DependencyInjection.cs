﻿using System.Reflection;
using System.Text;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.MapperProfiles;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Categories.MapperProfiles;
using LevvaCoins.Application.Categories.Services;
using LevvaCoins.Application.Middlewares;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Mapper;
using LevvaCoins.Application.Transactions.Services;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using LevvaCoins.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MysqlDbContext>(opt =>
            {
                opt.UseSqlite(
                    configuration.GetConnectionString("DefaultConectionSqlite")!,
                    x => x.MigrationsAssembly(typeof(MysqlDbContext).Assembly.FullName)
                );
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Token:Key")!);

            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.Load("LevvaCoins.Application")));
            services.AddAutoMapper(typeof(AccountProfile), typeof(CategoryProfile), typeof(TransactionProfile));
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("_myAllowSpecificOrigins", policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "API LevvaCoins", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                                  "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                                  "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",

                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void UseApi(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMidleware>();
        }
    }
}
