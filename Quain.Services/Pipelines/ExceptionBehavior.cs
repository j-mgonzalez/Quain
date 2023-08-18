namespace Quain.Services.Pipelines
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using Quain.Services.Exceptions;

    public sealed class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ArgumentException ex)
            {
                throw new QuainValidationException(request, new ValidationException(ex.Message, new[] { new ValidationFailure(ex.ParamName, ex.Message) }));
            }
            catch (QuainException)
            {
                throw;
            }
            catch (ValidationException ex)
            {
                throw new QuainValidationException(request, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new QuainHandlerException(ex.StatusCode.Value, request, ex);
            }
            catch (Exception ex) when (((QuainHandlerException)ex.InnerException)?.StatusCode is not null)
            {
                var statusCode = ((QuainHandlerException)ex.InnerException).StatusCode;
                throw new QuainHandlerException(statusCode, request, ex);
            }
            catch (Exception ex)
            {
                throw new QuainHandlerException(HttpStatusCode.InternalServerError, request, ex);
            }
        }
    }
}