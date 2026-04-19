using System.ComponentModel.DataAnnotations;
using System.Net;
using TMS.api.DataTransferObjects;

namespace TMS.api.Shared.ExceptionMiddleware
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
                //_logger.LogError($"Something went wrong: {ex.InnerException.Message}");
                await this.HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionDto response = exception switch
            {
                BadRequestException _ => new ExceptionDto((int)HttpStatusCode.BadRequest, exception.Message),
                ApplicationException _ => new ExceptionDto((int)HttpStatusCode.BadRequest, "Application exception occurred."),
                KeyNotFoundException _ => new ExceptionDto((int)HttpStatusCode.NotFound, "The request key not found."),
                UnauthorizedAccessException _ => new ExceptionDto((int)HttpStatusCode.Unauthorized, "Unauthorized."),
                _ => new ExceptionDto((int)HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
