namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using FluentValidation;

    internal class UpdatePointsByCustomerIdCommandValidator : AbstractValidator<UpdatePointsByCustomerIdCommand>
    {
        public UpdatePointsByCustomerIdCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.PointsInput.NComp)
                .NotEmpty();
        }
    }
}
