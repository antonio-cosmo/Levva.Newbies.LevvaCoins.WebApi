using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using LevvaCoins.Api.Middlewares;
using Microsoft.OpenApi.Models;

namespace LevvaCoins.Api.Configuration;

public static class ControllersApiConfiguration
{
    private const string CORS_POLICY = "AllowLevvaCoinsOrigin";
    private const string ALLOWED_ORIGIN = "http://localhost:5173";

    public static IServiceCollection AddAndConfigureControllers( this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.WriteIndented = true;
            opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        });
        services.AddCors(opt => opt.AddPolicy(CORS_POLICY, opt => opt.WithOrigins(ALLOWED_ORIGIN).AllowAnyMethod().AllowAnyHeader()));
        services.AddDocumentation();

        return services;
    }
    private static IServiceCollection AddDocumentation( this IServiceCollection services )
    {
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

        return services;
    }
    public static WebApplication UseDocumentation( this WebApplication app )
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        return app;
    }
    public static WebApplication UseLevvacoinsStartup(this WebApplication app)
    {
        app.UseCors(CORS_POLICY);
        app.UseMiddleware<ExceptionHandlerMidleware>();
        return app;
    }
}
