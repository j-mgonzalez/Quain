namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository.Customers;
    using Quain.Services.DTO;

    public class UpdatePointsByCustomerIdHandler : IRequestHandler<UpdatePointsByCustomerIdCommand, UpdatePointsByCustomerIdResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public UpdatePointsByCustomerIdHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task<UpdatePointsByCustomerIdResponse> Handle(UpdatePointsByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetCustomerById(request.CustomerId, cancellationToken);

            if (request.PointsInput.PointsToUse > customer.Points.CurrentValue) throw new ApplicationException("No posee puntos suficientes realizar la transacción.");

            customer.UpdatePoints(request.PointsInput.PointsToUse * -1, request.UpdatedBy);

            var customerResult = await _customersRepository.Update(customer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return UpdatePointsByCustomerIdResponse.With(customerModel);
        }
    }
}
