using AutoMapper;
using DTOLayer.DTOs.AcademicYear;
using EntityLayer.Concrete;


namespace ExamCreator.AutoMapper
{
    public class AcademicYearProfile : Profile
    {
        public AcademicYearProfile()
        {
            CreateMap<AcademicYear, AcademicYearIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<AcademicYear, AcademicYearCreateDTO>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearEditDTO>().ReverseMap();
        }
    }
}
