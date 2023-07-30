namespace Quain.Services.Handlers.Customers.GetCustomer
{
    using Quain.Services.DTO;

    public class GetCustomerResponse
    {
        public CustomerDto CustomerDto { get; set; }
        private GetCustomerResponse(CustomerDto customerDto)
        {
            CustomerDto = customerDto;
        }

        public static GetCustomerResponse With(CustomerDto customerDto) 
            => new GetCustomerResponse(customerDto);
    }
}
