using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Response;

namespace ExamCreator.AutoMapper
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Response, ListResponse>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.QuestionTypeName, opt => opt.MapFrom(src => src.QuestionType.ResponseType))
                .ForMember(dest => dest.QuestionName, opt => opt.MapFrom(src => src.Question.Content))
                .ForMember(dest => dest.AcademicYearName, opt => opt.MapFrom(src => src.AcademicYear.Name))
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Response, CreateResponse>().ReverseMap();
            CreateMap<Response, EditResponse>().ReverseMap();
        }
    }
}
