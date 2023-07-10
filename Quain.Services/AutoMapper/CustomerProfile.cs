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
        }
    }
}
