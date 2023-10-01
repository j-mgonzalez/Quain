namespace Quain.Services.Handlers.Customers.GetCustomersClassified
{
    using FluentValidation;
    using Microsoft.IdentityModel.Tokens;

    internal class GetCustomersClassifiedCommandValidator : AbstractValidator<GetCustomersClassifiedCommand>
    {
        public GetCustomersClassifiedCommandValidator()
        {
        }
    }
}
