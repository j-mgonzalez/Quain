namespace Quain.Services.Handlers.Authentication.Register
{
    using Quain.Services.DTO;
    using System.Net;

    public class RegisterResponse
    {
        public LoginResponseDTO LoginResponseDto { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        private RegisterResponse(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
        {
            LoginResponseDto = loginResponseDTO;
            StatusCode = statusCode;
        }

		public static RegisterResponse With(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
			=> new RegisterResponse(loginResponseDTO, statusCode);

		public static RegisterResponse WithError(IEnumerable<string> errors, HttpStatusCode statusCode)
			=> new RegisterResponse(new LoginResponseDTO { Errors = errors }, statusCode);
	}
}
