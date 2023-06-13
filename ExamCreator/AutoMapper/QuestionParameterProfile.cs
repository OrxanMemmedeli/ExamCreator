using AutoMapper;
using DTOLayer.DTOs.QuestionParameter;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class QuestionParameterProfile : Profile
    {
        public QuestionParameterProfile()
        {
            CreateMap<QuestionParameter, QuestionParameterIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName))
                .ReverseMap();

            CreateMap<QuestionParameter, QuestionParameterCreateDTO>().ReverseMap();
            CreateMap<QuestionParameter, QuestionParameterEditDTO>().ReverseMap();
        }
    }
}
