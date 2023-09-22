using System.Net;
using System.Text.Json;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LevvaCoins.Api.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly NotificationContext _notificationContext;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public NotificationFilter(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            context.HttpContext.Response.ContentType = "application/json";

            List<object> listErrors = new(_notificationContext.Notifications);

            var notifications = JsonSerializer.Serialize(new ApiResponse(
                false, null, listErrors
            ),_jsonSerializerOptions);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}