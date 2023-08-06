namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
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

            customer.UpdatePoints(request.PointsInput.Amount * -1, request.PointsInput.NComp);

            var customerResult = await _customersRepository.Update(customer, cancellationToken);

            var customerModel = _mapper.Map<CustomerDto>(customerResult);

            return UpdatePointsByCustomerIdResponse.With(customerModel);
        }
    }
}
