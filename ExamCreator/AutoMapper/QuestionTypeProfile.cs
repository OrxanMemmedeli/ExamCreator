using AutoMapper;
using DTOLayer.DTOs.QuestionType;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            CreateMap<QuestionType, QuestionTypeIndexDTO>().ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<QuestionType, QuestionTypeCreateDTO>().ReverseMap();
            CreateMap<QuestionType, QuestionTypeEditDTO>().ReverseMap();
        }
    }
}
