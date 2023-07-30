namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using MediatR;
    using Quain.Services.Inputs;

    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public string CodClient { get; set; }

        public string NComp { get; set; }

        private CreateCustomerCommand(string codClient, string nComp)
        {
            CodClient = codClient;
            NComp = nComp;
        }

        public static CreateCustomerCommand From(string codClient, string nComp) 
            => new CreateCustomerCommand(codClient, nComp);
    }
}
