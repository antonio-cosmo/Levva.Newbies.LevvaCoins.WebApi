﻿using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using LevvaCoins.Application.Users.Interfaces;
using LevvaCoins.Application.Users.MapperProfiles;
using LevvaCoins.Application.Users.Services;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Categories.MapperProfiles;
using LevvaCoins.Application.Categories.Services;
using LevvaCoins.Application.Middlewares;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Mapper;
using LevvaCoins.Application.Transactions.Services;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using LevvaCoins.Infra.Data.Interface;
using LevvaCoins.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

namespace LevvaCoins.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IContext,MysqlDbContext>(opt =>
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

            services.AddControllers().AddJsonOptions(opt => {
                opt.JsonSerializerOptions.WriteIndented = true;
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opt.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
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
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAnyOrigin", opt =>
                {
                    opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public static void UseWebApi(this WebApplication app)
        {
            app.UseCors("AllowAnyOrigin");
            app.UseMiddleware<ExceptionHandlerMidleware>();
            app.UseMiddleware<AuthorizationExceptionHandlerMidleware>();
        }
    }
}
