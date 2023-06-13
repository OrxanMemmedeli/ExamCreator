using AutoMapper;
using DTOLayer.DTOs.Subject;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectIndexDTO>().ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Subject, SubjectCreateDTO>().ReverseMap();
            CreateMap<Subject, SubjectEditDTO>().ReverseMap();
        }
    }
}
