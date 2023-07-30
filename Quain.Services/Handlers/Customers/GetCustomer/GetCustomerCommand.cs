namespace Quain.Services.Handlers.Customers.GetCustomer
{
    using MediatR;

    public class GetCustomerCommand : IRequest<GetCustomerResponse>
    {
        public string CodClient { get; set; }

        private GetCustomerCommand(string codClient)
        {
            CodClient = codClient;
        }

        public static GetCustomerCommand From(string codClient) 
            => new GetCustomerCommand(codClient);
    }
}
