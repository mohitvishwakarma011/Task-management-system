namespace TMS.api.Shared.ExceptionMiddleware
{
    public class BadRequestException : Exception
    {
        private const int ErrorStatusCode = 400;

        public int StatusCode { get; set; } = ErrorStatusCode;
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
