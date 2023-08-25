namespace Quain.Services.Handlers.Customers.CreateCustomer
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Domain.Models;
    using Quain.Repository;
    using Quain.Repository.Clients;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
    using Quain.Services.DTO;

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IPointsChangeRepository _pointsChangeRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomersRepository customersRepository, IPointsChangeRepository pointsChangeRepository, IClientRepository clientRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _pointsChangeRepository = pointsChangeRepository;
            _clientRepository = clientRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomer( 
                request.CodClient ?? "", 
                request.Cuit ?? "", 
                request.Name ?? "",
                cancellationToken);

            if (customer != null) return CreateCustomerResponse.With(_mapper.Map<CustomerDto>(customer));

            var billWasUsed = await _pointsChangeRepository.BillNumberWasUsed(request.NComp);

            if (billWasUsed) throw new ApplicationException($"La factura {request.NComp} ya fue utilizada previamente.");

            var client = await _clientRepository.GetClientByCodClientCuitName(request.CodClient ?? "", request.Name ?? "", request.Cuit ?? "");

            var sale = await _salesRepository.GetSale(request.NComp);
            
            var newCustomer = _mapper.Map<Client, Customer>(client, 
                opt => opt.AfterMap((_, dest) => dest.SetPoints(ConverToInt(sale.Importe), request.UpdatedBy, request.NComp)));
            
            var customerResult = await _customersRepository.Add(newCustomer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return CreateCustomerResponse.With(customerModel);
        }

        private int ConverToInt(decimal value) => Decimal.ToInt32(value);
    }
}
