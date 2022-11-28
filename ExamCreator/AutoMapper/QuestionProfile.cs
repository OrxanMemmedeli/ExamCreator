using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Question;

namespace ExamCreator.AutoMapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, ListQuestion>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section.Name))
                .ForMember(dest => dest.QuestionLevelName, opt => opt.MapFrom(src => src.QuestionLevel.Name))
                .ForMember(dest => dest.QuestionTypeName, opt => opt.MapFrom(src => src.QuestionType.ResponseType))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.AcademicYearName, opt => opt.MapFrom(src => src.AcademicYear.Name))
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Question, CreateQuestion>().ReverseMap();
            CreateMap<Question, EditQuestion>().ReverseMap();
        }
    }
}
