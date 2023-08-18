namespace Quain.Services.Exceptions
{
    using System.Collections.Generic;
    using System.Net;
    using FluentValidation;
    using FluentValidation.Results;

    public class QuainValidationException : QuainHandlerException
    {
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public QuainValidationException(object request, ValidationException innerException) : base(HttpStatusCode.BadRequest, request, innerException)
        {
            Errors = innerException.Errors;
        }

        public QuainValidationException(object request, string message, string propertyName) : this(request, new ValidationException(message, new[] { new ValidationFailure(propertyName, message) }))
        {
        }
    }
}