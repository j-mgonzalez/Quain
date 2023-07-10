namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Domain.Models;
    using Quain.Repository.Customers;
    using Quain.Services.DTO;

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request.CustomerInput);

            var customerResult = await _customersRepository.Add(customer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return CreateCustomerResponse.With(customerModel);
        }
    }
}
