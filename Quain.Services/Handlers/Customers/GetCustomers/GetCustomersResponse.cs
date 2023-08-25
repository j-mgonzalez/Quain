namespace Quain.Services.Handlers.Customers.GetCustomers
{
    using Quain.Services.DTO;

    public class GetCustomersResponse
    {
        public IEnumerable<CustomerDto> CustomerDtos { get; set; }
        private GetCustomersResponse(IEnumerable<CustomerDto> customerDtos)
        {
            CustomerDtos = customerDtos;
        }

        public static GetCustomersResponse With(IEnumerable<CustomerDto> customerDtos) 
            => new GetCustomersResponse(customerDtos);
    }
}
