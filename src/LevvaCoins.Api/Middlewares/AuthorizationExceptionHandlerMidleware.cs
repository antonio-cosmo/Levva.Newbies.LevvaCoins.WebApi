﻿using System.Text.Json;
using LevvaCoins.Api.Common;

namespace LevvaCoins.Api.Middlewares;

public class AuthorizationExceptionHandlerMidleware
{
    private readonly RequestDelegate _next;

    public AuthorizationExceptionHandlerMidleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
            context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            await WriteErrorResponse(context);
        }
    }

    private static async Task WriteErrorResponse(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorResponse
        (
            true,
            "Usuario não autenticado"
        );

        var json = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(json);
    }
}