namespace Quain.Services.Handlers.Customers.UpdateCustomerPoints
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository.Clients;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
    using Quain.Services.DTO;

    public class UpdateCustomerPointsHandler : IRequestHandler<UpdateCustomerPointsCommand, UpdateCustomerPointsResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerPointsHandler(ICustomersRepository customersRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerPointsResponse> Handle(UpdateCustomerPointsCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomer(request.CodClient, cancellationToken);

            if (customer == null) throw new ApplicationException("Customer not found");

            var sale = await _salesRepository.GetSale(request.NComp);

            customer.UpdatePoints(ConverToInt(sale.TotalFacturado), request.NComp);

            var customerResult = await _customersRepository.Update(customer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return UpdateCustomerPointsResponse.With(customerModel);
        }

        private int ConverToInt(decimal value) => Decimal.ToInt32(value);
    }
}
