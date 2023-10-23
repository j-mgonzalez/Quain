namespace Quain.Services.Handlers.Authentication.Login
{
    using FluentValidation;
    using Quain.Services.Handlers.Authentication.Register;

    public class LoginCommandValidator : AbstractValidator<RegisterCommand>
    {
        public LoginCommandValidator()
        {
        }
    }
}
