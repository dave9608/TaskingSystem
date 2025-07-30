using System.Net;
using System.Text.Json;
using TaskingSystem.Application.Exceptions;

namespace TaskingSystem.Api.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        object response;

        switch (exception)
        {
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                response = new { error = notFoundException.Message };
                break;
            default:
                statusCode = HttpStatusCode.InternalServerError;
                response = new { error = "An internal server error has occurred." };
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}