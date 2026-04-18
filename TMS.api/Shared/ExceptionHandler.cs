using System.Text.Json;

namespace TMS.api.Shared
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;
        public ExceptionHandler(RequestDelegate requestDelegate, ILogger<ExceptionHandler> logger)
        {
            _next = requestDelegate;
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
                _logger.LogError($"Something went wrong: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
