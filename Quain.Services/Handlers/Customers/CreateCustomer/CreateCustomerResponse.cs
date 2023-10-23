namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using Quain.Services.DTO;
    using System.Net;

    public class CreateCustomerResponse
    {
        public CustomerDto CustomerDto { get; set; }

        public ErrorResponseDTO ErrorResponseDTO { get; set; }

        private CreateCustomerResponse(CustomerDto customerDto, ErrorResponseDTO errorResponseDTO)
        {
            CustomerDto = customerDto;
            ErrorResponseDTO = errorResponseDTO;
        }

        public static CreateCustomerResponse With(CustomerDto customerDto)
            => new CreateCustomerResponse(customerDto, ErrorResponseDTO.Created());

        public static CreateCustomerResponse With(string message, HttpStatusCode statusCode)
            => new CreateCustomerResponse(null, new ErrorResponseDTO(message, statusCode));
    }
}
