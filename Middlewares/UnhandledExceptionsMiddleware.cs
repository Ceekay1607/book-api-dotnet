using System.Net;
using Newtonsoft.Json;

namespace book_api;

public class UnhandledExceptionsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UnhandledExceptionsMiddleware> _logger;

    public UnhandledExceptionsMiddleware(RequestDelegate next, ILogger<UnhandledExceptionsMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var result = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An error occurred while processing your request"
        };

        var jsonResponse = JsonConvert.SerializeObject(result);
        return context.Response.WriteAsync(jsonResponse);
    }

}
