namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using Quain.Services.DTO;

    public class UpdateCustomerPointsResponse
    {
        public CustomerDto CustomerDto { get; set; }
        private UpdateCustomerPointsResponse(CustomerDto customerDto)
        {
            CustomerDto = customerDto;
        }

        public static UpdateCustomerPointsResponse With(CustomerDto customerDto) 
            => new UpdateCustomerPointsResponse(customerDto);
    }
}
