namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using Quain.Services.DTO;
	using System.Net;

    public class UpdatePointsByCustomerIdResponse
    {
        public CustomerDto CustomerDto { get; set; }

		public ErrorResponseDTO ErrorResponseDTO { get; set; }
		private UpdatePointsByCustomerIdResponse(CustomerDto customerDto, ErrorResponseDTO errorResponseDTO)
        {
            CustomerDto = customerDto;
            ErrorResponseDTO = errorResponseDTO;
        }

        public static UpdatePointsByCustomerIdResponse With(CustomerDto customerDto) 
            => new UpdatePointsByCustomerIdResponse(customerDto, ErrorResponseDTO.Ok());

		public static UpdatePointsByCustomerIdResponse With(string message, HttpStatusCode statusCode)
			=> new UpdatePointsByCustomerIdResponse(null, new ErrorResponseDTO(message, statusCode));
	}
}
