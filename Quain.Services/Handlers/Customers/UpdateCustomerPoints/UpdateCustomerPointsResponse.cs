namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using Quain.Services.DTO;
    using System.Net;

    public class UpdateCustomerPointsResponse
    {
        public CustomerDto CustomerDto { get; set; }

        public ErrorResponseDTO ErrorResponseDTO { get; set; }

        private UpdateCustomerPointsResponse(CustomerDto customerDto, ErrorResponseDTO errorResponseDTO)
        {
            CustomerDto = customerDto;
            ErrorResponseDTO = errorResponseDTO;
        }

        public static UpdateCustomerPointsResponse With(CustomerDto customerDto)
            => new UpdateCustomerPointsResponse(customerDto, ErrorResponseDTO.Ok());

        public static UpdateCustomerPointsResponse With(string message, HttpStatusCode statusCode)
            => new UpdateCustomerPointsResponse(null, new ErrorResponseDTO(message, statusCode));
    }
}
