namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using FluentValidation;

    internal class UpdateCustomerPointsCommandValidator : AbstractValidator<UpdateCustomerPointsCommand>
    {
        public UpdateCustomerPointsCommandValidator()
        {
            RuleFor(x => x.NComp)
                .NotEmpty();

            RuleFor(x => x.CodClient)
                .NotEmpty();
        }
    }
}
