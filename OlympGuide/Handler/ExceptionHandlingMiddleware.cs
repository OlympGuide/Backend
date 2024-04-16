using OlympGuide.Domain.Features.User;
using System.Text.Json;

namespace OlympGuide.Handler
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(UserNotFoundException ex)
            {
                _logger.LogError(ex, $"Unhandled exception from endpoint: {context.GetEndpoint()!.DisplayName}.");
                _logger.LogError(ex.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = ex.Message }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception from endpoint: {context.GetEndpoint()!.DisplayName}.");
                _logger.LogError(ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = ex.Message }));
            }
        }
    }
}
