namespace Quain.Services.Handlers.Authentication.Login
{
    using Quain.Services.DTO;
    using System.Net;

    public class LoginResponse
    {
        public LoginResponseDTO LoginResponseDto { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        private LoginResponse(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
        {
            LoginResponseDto = loginResponseDTO;
            StatusCode = statusCode;
        }

		public static LoginResponse With(LoginResponseDTO loginResponseDTO, HttpStatusCode statusCode)
			=> new LoginResponse(loginResponseDTO, statusCode);

		public static LoginResponse Unauthorized(string userName)
			=> new LoginResponse(new LoginResponseDTO { Token = string.Empty, UserName = userName, Message = "Cuenta o contraseña incorrecta." }, HttpStatusCode.Unauthorized);

	}
}
