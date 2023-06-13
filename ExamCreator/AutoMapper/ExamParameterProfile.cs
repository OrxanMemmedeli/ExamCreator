using AutoMapper;
using DTOLayer.DTOs.ExamParameter;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class ExamParameterProfile : Profile
    {
        public ExamParameterProfile()
        {
            CreateMap<ExamParameter, ExamParameterIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<ExamParameter, ExamParameterCreateDTO>().ReverseMap();
            CreateMap<ExamParameter, ExamParameterEditDTO>().ReverseMap();
        }
    }
}
