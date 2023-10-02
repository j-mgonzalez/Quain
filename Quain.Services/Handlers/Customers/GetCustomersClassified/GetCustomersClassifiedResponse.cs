namespace Quain.Services.Handlers.Customers.GetCustomersClassified
{
    using Quain.Services.DTO;

    public class GetCustomersClassifiedResponse
    {
        public IEnumerable<ClientClassifiedDTO> ClientsDtos { get; set; }

        private GetCustomersClassifiedResponse(IEnumerable<ClientClassifiedDTO> clientsDtos)
        {
            ClientsDtos = clientsDtos;
        }

        public static GetCustomersClassifiedResponse With(IEnumerable<ClientClassifiedDTO> clientsDtos) 
            => new GetCustomersClassifiedResponse(clientsDtos);
    }
}
