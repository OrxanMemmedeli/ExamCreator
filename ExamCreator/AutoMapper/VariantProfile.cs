using AutoMapper;
using DTOLayer.DTOs.Variant;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class VariantProfile : Profile
    {
        public VariantProfile()
        {
            CreateMap<Variant, VariantIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Variant, VariantCreateDTO>().ReverseMap();
            CreateMap<Variant, VariantEditDTO>().ReverseMap();
        }
    }
}
