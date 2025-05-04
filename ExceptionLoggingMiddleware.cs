using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class ExceptionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionLoggingMiddleware> _logger;

    public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Continue to next middleware/controller
        }
        catch (Exception ex)
        {
            // LOG THE ERROR
            _logger.LogError(ex, $"Unhandled Exception: {ex.Message}");

            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred.");

           
        }
    }
}
