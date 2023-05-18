using AutoMapper;
using DTOLayer.DTOs.Question;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionIndexDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section.Name))
                .ForMember(dest => dest.QuestionLevelName, opt => opt.MapFrom(src => src.QuestionLevel.Name))
                .ForMember(dest => dest.QuestionTypeName, opt => opt.MapFrom(src => src.QuestionType.ResponseType))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.AcademicYearName, opt => opt.MapFrom(src => src.AcademicYear.Name))
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Question, QuestionCreateDTO>().ReverseMap();
            CreateMap<Question, QuestionEditDTO>().ReverseMap();
        }
    }
}
