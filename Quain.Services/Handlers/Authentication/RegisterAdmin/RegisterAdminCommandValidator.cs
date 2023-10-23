namespace Quain.Services.Handlers.Authentication.RegisterAdmin
{
    using FluentValidation;

    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator()
        {
        }
    }
}
