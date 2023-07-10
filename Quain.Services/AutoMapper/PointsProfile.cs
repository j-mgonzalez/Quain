namespace Quain.Services.AutoMapper
{
    using global::AutoMapper;
    using Quain.Domain.Models;
    using Quain.Services.DTO;
    using Quain.Services.Inputs;

    public class PointsProfile : Profile
    {
        public PointsProfile()
        {
            CreateMap<Points, PointsDto>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.CurrentValue));

            CreateMap<PointsInput, Points>()
                .ForMember(dest => dest.CurrentValue, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
