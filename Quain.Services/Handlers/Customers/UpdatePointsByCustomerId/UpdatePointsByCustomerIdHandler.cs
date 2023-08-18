namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
    using Quain.Services.DTO;

    public class UpdatePointsByCustomerIdHandler : IRequestHandler<UpdatePointsByCustomerIdCommand, UpdatePointsByCustomerIdResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IPointsChangeRepository _pointsChangeRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public UpdatePointsByCustomerIdHandler(ICustomersRepository customersRepository, IPointsChangeRepository pointsChangeRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _pointsChangeRepository = pointsChangeRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<UpdatePointsByCustomerIdResponse> Handle(UpdatePointsByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomerById(request.CustomerId, cancellationToken);

            var billWasUsed = await _pointsChangeRepository.BillNumberWasUsed(request.PointsInput.NComp);

            if (billWasUsed) throw new ApplicationException($"La factura {request.PointsInput.NComp} ya fue utilizada previamente.");

            var sale = await _salesRepository.GetSale(request.PointsInput.NComp, request.PointsInput.CodClient);

            customer.UpdatePoints(sale.Importe, sale.N_COMP);

            var customerResult = await _customersRepository.Update(customer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return UpdatePointsByCustomerIdResponse.With(customerModel);
        }
    }
}
