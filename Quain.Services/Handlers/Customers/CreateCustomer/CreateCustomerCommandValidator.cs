namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using FluentValidation;

    internal class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.NComp)
               .NotEmpty();

            RuleFor(x => x.CodClient)
                .NotEmpty();

            RuleFor(x => x.UpdatedBy)
                .NotEmpty();
        }
    }
}
