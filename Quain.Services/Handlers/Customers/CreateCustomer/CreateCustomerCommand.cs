namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using MediatR;
    using Quain.Services.Inputs;

    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public CustomerInput CustomerInput { get; set; }

        private CreateCustomerCommand(CustomerInput customerInput)
        {
            CustomerInput = customerInput;
        }

        public static CreateCustomerCommand From(CustomerInput customerInput) 
            => new CreateCustomerCommand(customerInput);
    }
}
