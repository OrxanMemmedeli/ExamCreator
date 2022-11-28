using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.QuestionType;

namespace ExamCreator.AutoMapper
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            CreateMap<QuestionType, ListQuestionType>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<QuestionType, CreateQuestionType>().ReverseMap();
            CreateMap<QuestionType, EditQuestionType>().ReverseMap();
        }
    }
}
