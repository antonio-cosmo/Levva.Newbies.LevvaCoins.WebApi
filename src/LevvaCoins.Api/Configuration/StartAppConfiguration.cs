using LevvaCoins.Api.Middlewares;

namespace LevvaCoins.Api.Configuration;

public static class StartAppConfiguration
{
    private const string CORS_POLICY = "AllowLevvaCoinsOrigin";
    public static void UseLevvacoinsStartup(this WebApplication app)
    {
        app.UseCors(CORS_POLICY);
        app.UseMiddleware<ExceptionHandlerMidleware>();
        app.UseMiddleware<AuthorizationExceptionHandlerMidleware>();
    }
}
