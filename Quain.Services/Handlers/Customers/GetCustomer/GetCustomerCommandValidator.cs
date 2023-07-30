namespace Quain.Services.Handlers.Customers.GetCustomer
{
    using FluentValidation;

    internal class GetCustomerCommandValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerCommandValidator()
        {
            RuleFor(x => x.CodClient)
                .NotEmpty();
        }
    }
}
