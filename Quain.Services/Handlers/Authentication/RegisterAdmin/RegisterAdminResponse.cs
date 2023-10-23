namespace Quain.Services.Handlers.Authentication.RegisterAdmin
{
    using Quain.Services.DTO;
    using System.Net;

    public class RegisterAdminResponse
    {
        public LoginResponseDTO LoginResponseDto { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        private RegisterAdminResponse(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
        {
            LoginResponseDto = loginResponseDTO;
            StatusCode = statusCode;
        }

		public static RegisterAdminResponse With(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
			=> new RegisterAdminResponse(loginResponseDTO, statusCode);

		public static RegisterAdminResponse WithError(IEnumerable<string> errors, HttpStatusCode statusCode)
			=> new RegisterAdminResponse(new LoginResponseDTO { Errors = errors }, statusCode);
	}
}
