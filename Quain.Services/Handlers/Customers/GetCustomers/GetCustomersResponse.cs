namespace Quain.Services.Handlers.Customers.GetCustomers
{
    using Quain.Services.DTO;
    using System.Net;

    public class GetCustomersResponse
    {
        public IEnumerable<CustomerDto> CustomerDtos { get; set; }

        public ErrorResponseDTO ErrorResponseDTO { get; set; }

        private GetCustomersResponse(IEnumerable<CustomerDto> customerDtos, ErrorResponseDTO errorResponseDTO)
        {
            CustomerDtos = customerDtos;
            ErrorResponseDTO = errorResponseDTO;
        }

        public static GetCustomersResponse With(IEnumerable<CustomerDto> customerDtos)
            => new GetCustomersResponse(customerDtos, ErrorResponseDTO.Ok());

        public static GetCustomersResponse With()
            => new GetCustomersResponse(null, new ErrorResponseDTO("No se encontraron clientes con esos datos.", HttpStatusCode.NoContent));
    }
}
