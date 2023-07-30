namespace Quain.Services.AutoMapper
{
    using global::AutoMapper;
    using Quain.Domain.Models;
    using Quain.Services.DTO;
    using Quain.Services.Inputs;

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerInput, Customer>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Client, Customer>()
                .ForMember(dest => dest.CodClient, opt => opt.MapFrom(src => src.COD_CLIENT))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NOM_COM));
        }
    }
}
