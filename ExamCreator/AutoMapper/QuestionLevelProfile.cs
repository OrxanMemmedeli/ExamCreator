using AutoMapper;
using DTOLayer.DTOs.QuestionLevel;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class QuestionLevelProfile : Profile
    {
        public QuestionLevelProfile()
        {
            CreateMap<QuestionLevel, QuestionLevelIndexDTO>().ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<QuestionLevel, QuestionLevelCreateDTO>().ReverseMap();
            CreateMap<QuestionLevel, QuestionLevelEditDTO>().ReverseMap();
        }
    }
}
