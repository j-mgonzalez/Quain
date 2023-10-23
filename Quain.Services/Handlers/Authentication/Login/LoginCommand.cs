namespace Quain.Services.Handlers.Authentication.Login
{
    using MediatR;
    using Quain.Domain.Models;

    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginModel LoginModel { get; set; }

        private LoginCommand(LoginModel loginModel)
        {
            LoginModel = loginModel;
        }

        public static LoginCommand From(LoginModel loginModel)
            => new LoginCommand(loginModel);
    }
}
