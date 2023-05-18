using AutoMapper;
using DTOLayer.DTOs.Section;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionIndexDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Section, SectionCreateDTO>().ReverseMap();
            CreateMap<Section, SectionEditDTO>().ReverseMap();
        }
    }
}
