using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.AcademicYear;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;

namespace ExamCreator.AutoMapper
{
    public class AcademicYearProfile : Profile
    {
        public AcademicYearProfile()
        {
            CreateMap<AcademicYear, ListAcademicYear>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<AcademicYear, CreateAcademicYear>().ReverseMap();
            CreateMap<AcademicYear, EditAcademicYear>().ReverseMap();
        }
    }
}
