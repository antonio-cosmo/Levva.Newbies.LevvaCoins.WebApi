using System.Text.Json;
using LevvaCoins.Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace LevvaCoins.Application.Middlewares
{
    public class AuthorizationExceptionHandlerMidleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationExceptionHandlerMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Chame o próximo middleware na pipeline
            await _next(context);

            // Verifique se há erros de autorização
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {

                context.Response.ContentType = "application/json";

                var errorResponse = new ErrorResponse
                {
                    HasError = true,
                    Message = "Usuario não autenticado"
                };

                var json = JsonSerializer.Serialize(errorResponse);

                // Escrever a resposta de erro na resposta HTTP
                await context.Response.WriteAsync(json);
            }
        }
    }
}
