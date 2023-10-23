namespace Quain.Services.Handlers.Authentication.Register
{
    using FluentValidation;

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
        }
    }
}
