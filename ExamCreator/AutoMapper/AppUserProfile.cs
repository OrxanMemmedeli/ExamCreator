using AutoMapper;
using DTOLayer.DTOs.AcademicYear;
using DTOLayer.DTOs.AppUser;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AcademicYearIndexDTO>().ReverseMap();
            CreateMap<AppUser, AppUserCreateEditDTO>().ReverseMap();
        }
    }
}
