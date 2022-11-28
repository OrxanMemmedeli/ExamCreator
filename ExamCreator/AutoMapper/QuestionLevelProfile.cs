using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.QuestionLevel;

namespace ExamCreator.AutoMapper
{
    public class QuestionLevelProfile : Profile
    {
        public QuestionLevelProfile()
        {
            CreateMap<QuestionLevel, ListQuestionLevel>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<QuestionLevel, CreateQuestionLevel>().ReverseMap();
            CreateMap<QuestionLevel, EditQuestionLevel>().ReverseMap();
        }
    }
}
