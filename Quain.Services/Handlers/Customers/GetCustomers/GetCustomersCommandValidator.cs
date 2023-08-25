namespace Quain.Services.Handlers.Customers.GetCustomers
{
    using FluentValidation;
    using Microsoft.IdentityModel.Tokens;

    internal class GetCustomersCommandValidator : AbstractValidator<GetCustomersCommand>
    {
        public GetCustomersCommandValidator()
        {
            RuleFor(x => x.CodClient)
                .NotEmpty()
                .When(x => x.Cuit.IsNullOrEmpty() && x.Name.IsNullOrEmpty());


            RuleFor(x => x.Cuit)
                .NotEmpty()
                .When(x => x.CodClient.IsNullOrEmpty() && x.Name.IsNullOrEmpty());

            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Cuit.IsNullOrEmpty() && x.CodClient.IsNullOrEmpty());
        }
    }
}
