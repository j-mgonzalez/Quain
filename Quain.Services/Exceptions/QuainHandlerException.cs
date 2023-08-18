namespace Quain.Services.Exceptions
{
    using System;
    using System.Net;

    public class QuainHandlerException : QuainException
    {
        public string ExceptionType => InnerException.GetType().Name;
        public string RequestType => Request.GetType().Name;
        public object Request { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public QuainHandlerException(HttpStatusCode statusCode, object request, Exception innerException)
            : this(statusCode, request, innerException, innerException.Message)
        {
        }

        public QuainHandlerException(HttpStatusCode statusCode, object request, Exception innerException, string message)
            : base(message, innerException)
        {
            Request = request;
            StatusCode = statusCode;
        }
    }
}