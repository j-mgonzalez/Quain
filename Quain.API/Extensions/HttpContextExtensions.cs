namespace Quain.API.Extensions
{
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Quain.Exceptions.Response;

    public static class HttpContextExtensions
    {
        public static Task WriteResponseAsync(this HttpContext context, ExceptionResponse exceptionResponse)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            var jsonContent = JsonSerializer.Serialize(exceptionResponse,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return context.Response.WriteAsync(jsonContent);
        }
    }
}