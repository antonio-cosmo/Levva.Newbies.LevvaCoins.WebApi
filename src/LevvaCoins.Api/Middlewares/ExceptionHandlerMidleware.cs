﻿using System.Text.Json;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Exceptions;

namespace LevvaCoins.Api.Middlewares;

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

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
            context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await NotAuthorized(context);
            }
        }
        catch (ModelNotFoundException ex)
        {
            await WriteErrorResponse(context, ex);
        }
        catch (ModelAlreadyExistsException ex)
        {
            await WriteErrorResponse(context, ex);
        }
        catch (EntityValidationException ex)
        {
            await WriteErrorResponse(context, ex);
        }
        catch (NotAuthorizedException ex)
        {
            await WriteErrorResponse(context, ex, 401);
        }
        catch (Exception ex)
        {
            await WriteErrorResponse(context, ex, 500);
        }
    }
    private async Task WriteErrorResponse(HttpContext context, Exception ex, int statusCode = 400)
    {
        var body = CreateErrorResponse(ex);
        await SetupResponse(context, statusCode, body);
    }
    private async Task SetupResponse(HttpContext context, int statusCode, ErrorResponseModelOutput body)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        // Escrever a resposta de erro na resposta HTTP
        await context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }
    private static ErrorResponseModelOutput CreateErrorResponse(Exception ex)
    {
        return new ErrorResponseModelOutput
        (
            true,
            ex.Message
        );
    }
    private static async Task NotAuthorized(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorResponseModelOutput
        (
            true,
            "Usuario não autenticado"
        );

        var json = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(json);
    }
}
