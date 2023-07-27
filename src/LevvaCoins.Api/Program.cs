using LevvaCoins.Api.Configuration;
using LevvaCoins.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAndConfigureControllers()
    .AddLevvaCoinsService(builder.Configuration);

var app = builder.Build();

app.UseDocumentation();
app.UseLevvacoinsStartup();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
