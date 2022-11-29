using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Section;

namespace ExamCreator.AutoMapper
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, ListSection>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Section, CreateSection>().ReverseMap();
            CreateMap<Section, EditSection>().ReverseMap();
        }
    }
}
