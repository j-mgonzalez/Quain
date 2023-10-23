namespace Quain.Services.DTO
{
    using System.Net;

    public class ErrorResponseDTO
    {
        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ErrorResponseDTO(string message, HttpStatusCode statusCode)
        {
            ErrorMessage = message;
            StatusCode = statusCode;
        }

        public static ErrorResponseDTO Ok()
            => new ErrorResponseDTO(string.Empty, HttpStatusCode.OK);

        public static ErrorResponseDTO Created()
            => new ErrorResponseDTO(string.Empty, HttpStatusCode.Created);
    }
}
