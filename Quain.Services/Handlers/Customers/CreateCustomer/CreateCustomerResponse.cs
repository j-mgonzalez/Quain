namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using Quain.Services.DTO;

    public class CreateCustomerResponse
    {
        public CustomerDto CustomerDto { get; set; }
        private CreateCustomerResponse(CustomerDto customerDto)
        {
            CustomerDto = customerDto;
        }

        public static CreateCustomerResponse With(CustomerDto customerDto) 
            => new CreateCustomerResponse(customerDto);
    }
}
