namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using Quain.Services.DTO;

    public class UpdatePointsByCustomerIdResponse
    {
        public CustomerDto CustomerDto { get; set; }
        private UpdatePointsByCustomerIdResponse(CustomerDto customerDto)
        {
            CustomerDto = customerDto;
        }

        public static UpdatePointsByCustomerIdResponse With(CustomerDto customerDto) 
            => new UpdatePointsByCustomerIdResponse(customerDto);
    }
}
