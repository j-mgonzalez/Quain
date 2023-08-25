namespace Quain.Services.Handlers.Customers.GetCustomers
{
    using MediatR;

    public class GetCustomersCommand : IRequest<GetCustomersResponse>
    {
        public string CodClient { get; set; }

        public string Name { get; set; }

        public string Cuit { get; set; }

        private GetCustomersCommand(string codClient, string name, string cuit)
        {
            CodClient = codClient;
            Name = name;
            Cuit = cuit;
        }

        public static GetCustomersCommand From(string codClient, string name, string cuit) 
            => new GetCustomersCommand(codClient, name, cuit);
    }
}
