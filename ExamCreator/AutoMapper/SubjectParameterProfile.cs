using AutoMapper;
using DTOLayer.DTOs.SubjectParameter;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class SubjectParameterProfile : Profile
    {
        public SubjectParameterProfile()
        {
            CreateMap<SubjectParameter, SubjectParameterIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.ExamParameterName, opt => opt.MapFrom(src => src.ExamParameter.Name))
                .ReverseMap();

            CreateMap<SubjectParameter, SubjectParameterCreateDTO>().ReverseMap();
            CreateMap<SubjectParameter, SubjectParameterEditDTO>().ReverseMap();
        }
    }
}
