namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using MediatR;

    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public string CodClient { get; set; }

        public string NComp { get; set; }

        public string UpdatedBy { get; set; }

        public string Name { get; set; }

        public string Cuit { get; set; }

        private CreateCustomerCommand(string codClient, string nComp, string updatedBy, string name, string cuit)
        {
            CodClient = codClient;
            NComp = nComp;
            UpdatedBy = updatedBy;
            Name = name;
            Cuit = cuit;
        }

        public static CreateCustomerCommand From(string codClient, string nComp, string updatedBy, string name, string cuit) 
            => new CreateCustomerCommand(codClient, nComp, updatedBy, name, cuit);
    }
}
