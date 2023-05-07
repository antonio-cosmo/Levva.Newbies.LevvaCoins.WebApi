using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Domain.AppExceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace LevvaCoins.Application.Middlewares
{
    public class ExceptionHandlerMidleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public ExceptionHandlerMidleware(RequestDelegate next)
        {
            _next = next;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ModelNotFoundException ex)
            {
                var body = new ErrorResponse
                {
                    HasError = true,
                    Message = ex.Message
                };

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
            }
            catch (Exception ex)
            {
                var body = new ErrorResponse
                {
                    HasError = true,
                    Message = ex.Message
                };

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
            }
        }
    }
}
