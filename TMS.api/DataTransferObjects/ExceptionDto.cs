using System.Text.Json;

namespace TMS.api.DataTransferObjects
{
    public class ExceptionDto
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ExceptionDto(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
