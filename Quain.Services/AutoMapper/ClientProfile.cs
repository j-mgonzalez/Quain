namespace Quain.Services.AutoMapper
{
    using global::AutoMapper;
    using Quain.Domain.Models;
    using Quain.Services.DTO;

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientClassified, ClientClassifiedDTO>().ReverseMap();
        }
    }
}
