using AutoMapper;
using DTOLayer.DTOs.Exam;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.ExamParameterName, opt => opt.MapFrom(src => src.ExamParameter.Name))
                .ReverseMap();

            CreateMap<Exam, ExamCreateDTO>().ReverseMap();
            CreateMap<Exam, ExamEditDTO>().ReverseMap();
        }
    }
}