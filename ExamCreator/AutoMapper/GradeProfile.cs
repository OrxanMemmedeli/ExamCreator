using AutoMapper;
using DTOLayer.DTOs.Grade;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Grade, GradeCreateDTO>().ReverseMap();
            CreateMap<GradeEditDTO, Grade>()
                .ForMember(dest => dest.Name, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
                .ReverseMap();
        }
    }
}
