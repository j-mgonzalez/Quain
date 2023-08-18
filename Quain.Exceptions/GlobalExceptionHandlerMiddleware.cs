namespace Quain.Exceptions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Quain.Exceptions.Extensions;
    using Quain.Exceptions.Response;
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is QuainValidationException validationException)
            {
                return ProcessValidationError(context, validationException);
            }
            else if (exception is QuainHandlerException handlerException)
            {
                return ProcessHandlerError(context, handlerException);
            }
            else
            {
                return ProcessError(context, exception);
            }
        }

        private Task ProcessValidationError(HttpContext context, QuainValidationException validationException)
        {
            _logger.LogInformation("{0} procesando {1}: {2}",
                        validationException.ExceptionType,
                        validationException.RequestType,
                        validationException.Message
                    );

            var exceptionResponse = new ExceptionResponse
            {
                Status = (int)validationException.StatusCode,
                ErrorMessages = validationException.Errors.Select(x => $"Error: {x.AttemptedValue} was expected for property {x.PropertyName}.").ToList()
            };

            return context.WriteResponseAsync(exceptionResponse);
        }

        private Task ProcessHandlerError(HttpContext context, QuainHandlerException handlerException)
        {
            _logger.LogError("{0} procesando {1}: {2}\n{3}\nRequest: {4}",
                       handlerException.ExceptionType,
                        handlerException.RequestType,
                        handlerException.Message,
                        handlerException.InnerException,
                        JsonSerializer.Serialize(handlerException.Request)
                    );

            var exceptionResponse = new ExceptionResponse
            {
                Status = (int)handlerException.StatusCode,
                ErrorMessages = new List<string> { handlerException.Message }
            };

            return context.WriteResponseAsync(exceptionResponse);
        }

        private Task ProcessError(HttpContext context, Exception exception)
        {
            _logger.LogError("Error en {0}: {1}", context.GetEndpoint(), exception);

            var exceptionResponse = new ExceptionResponse
            {
                Status = (int)HttpStatusCode.InternalServerError,
                ErrorMessages = new List<string> { exception.Message }
            };

            return context.WriteResponseAsync(exceptionResponse);
        }
    }
}