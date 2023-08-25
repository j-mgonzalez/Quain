namespace Quain.Services.Handlers.Customers.GetCustomers
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository.Customers;
    using Quain.Services.DTO;

    public class GetCustomersHandler : IRequestHandler<GetCustomersCommand, GetCustomersResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public GetCustomersHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomersResponse> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomers(
                request.CodClient ?? "",
                request.Cuit ?? "", 
                request.Name ?? "", 
                cancellationToken);

            var customersModel = _mapper.Map<IEnumerable<CustomerDto>>(customer);

            return GetCustomersResponse.With(customersModel);
        }
    }
}
