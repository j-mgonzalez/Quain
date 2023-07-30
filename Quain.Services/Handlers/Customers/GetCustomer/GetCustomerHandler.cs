namespace Quain.Services.Handlers.Customers.GetCustomer
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Domain.Models;
    using Quain.Repository.Clients;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
    using Quain.Services.DTO;

    public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, GetCustomerResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public GetCustomerHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerResponse> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomer(request.CodClient, cancellationToken);

            if (customer == null) throw new ApplicationException("Customer not found");

            var customerModel = _mapper.Map<CustomerDto>(customer);

            return GetCustomerResponse.With(customerModel);
        }
    }
}
