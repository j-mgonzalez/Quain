namespace Quain.Services.Handlers.Customers.GetCustomersClassified
{
    using global::AutoMapper;
    using MediatR;
    using Quain.Repository.Clients;
    using Quain.Services.DTO;

    public class GetCustomersClassifiedHandler : IRequestHandler<GetCustomersClassifiedCommand, GetCustomersClassifiedResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetCustomersClassifiedHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomersClassifiedResponse> Handle(GetCustomersClassifiedCommand request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClientsClassified();

            var clientsModel = _mapper.Map<IEnumerable<ClientClassifiedDTO>>(clients);

            return GetCustomersClassifiedResponse.With(clientsModel);
        }
    }
}
