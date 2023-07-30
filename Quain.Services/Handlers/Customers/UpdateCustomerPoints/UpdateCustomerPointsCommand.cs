namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using MediatR;
    using Quain.Services.Inputs;

    public class UpdateCustomerPointsCommand : IRequest<UpdateCustomerPointsResponse>
    {
        public string CodClient { get; set; }

        public string NComp { get; set; }

        private UpdateCustomerPointsCommand(string codClient, string ncomp)
        {
            CodClient = codClient;
            NComp = ncomp;
        }

        public static UpdateCustomerPointsCommand From(string codClient, string ncomp) 
            => new UpdateCustomerPointsCommand(codClient, ncomp);
    }
}
