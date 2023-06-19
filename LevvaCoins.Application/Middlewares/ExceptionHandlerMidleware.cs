using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Validation;
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
                // Chame o próximo middleware na pipeline
                await _next(context);
            }
            catch (ModelNotFoundException ex)
            {
                await ErrorResponse(context, ex);
            }
            catch (ModelAlreadyExistsException ex)
            {
                await ErrorResponse(context, ex);
            }
            catch (DomainExceptionValidation ex)
            {
                await ErrorResponse(context, ex);
            }
            catch(NotAuthorizedException ex)
            {
                await ErrorResponse(context, ex, 401);
            }
            catch (Exception ex)
            {
                await ErrorResponse(context, ex, 500);
            }
        }
        private async Task ErrorResponse(HttpContext context, Exception ex, int statusCode = 400)
        {
            var body = new ErrorResponse
            {
                HasError = true,
                Message = ex.Message
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            // Escrever a resposta de erro na resposta HTTP
            await context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }
    }
}
