using System.Net;
using System.Text.Json;
using Online_Academy_Platform.Domain.Exceptions;

namespace Online_Academy_Platform.Api.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            var (statusCode, message, details) = MapException(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                status = (int)statusCode,
                message,
                details
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    private static (HttpStatusCode StatusCode, string Message, object? Details) MapException(Exception exception)
    {
        return exception switch
        {
            UnauthorizedException unauthorized => (
                HttpStatusCode.Unauthorized,
                unauthorized.Message,
                null),

            Application.Exceptions.NotFoundException notFound => (
                HttpStatusCode.NotFound,
                notFound.Message,
                new { notFound.ResourceName, notFound.ResourceKey }),

            Domain.Exceptions.NotFoundException notFound => (
                HttpStatusCode.NotFound,
                notFound.Message,
                null),

            ConflictException conflict => (
                HttpStatusCode.Conflict,
                conflict.Message,
                null),

            Domain.Exceptions.ValidationException validation => (
                HttpStatusCode.BadRequest,
                validation.Message,
                validation.Errors),

            Application.Exceptions.ValidationException validation => (
                HttpStatusCode.BadRequest,
                validation.Message,
                null),

            AppException app => (
                HttpStatusCode.BadRequest,
                app.Message,
                null),

            _ => (
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred. Please try again later.",
                (object?)null)
        };
    }
}