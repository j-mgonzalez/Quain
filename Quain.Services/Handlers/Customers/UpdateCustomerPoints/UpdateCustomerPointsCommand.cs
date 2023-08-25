namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using MediatR;

    public class UpdateCustomerPointsCommand : IRequest<UpdateCustomerPointsResponse>
    {
        public string CodClient { get; set; }

        public string NComp { get; set; }

        public string UpdatedBy { get; set; }

        private UpdateCustomerPointsCommand(string codClient, string ncomp, string updatedBy)
        {
            CodClient = codClient;
            NComp = ncomp;
            UpdatedBy = updatedBy;
        }

        public static UpdateCustomerPointsCommand From(string codClient, string ncomp, string updatedBy) 
            => new UpdateCustomerPointsCommand(codClient, ncomp, updatedBy);
    }
}
