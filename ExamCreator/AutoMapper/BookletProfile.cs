using AutoMapper;
using DTOLayer.DTOs.Booklet;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class BookletProfile : Profile
    {
        public BookletProfile()
        {
            CreateMap<Booklet, BookletIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName))
                .ForMember(dest => dest.ExamName, opt => opt.MapFrom(src => src.Exam.Name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.AcademicYearName, opt => opt.MapFrom(src => src.AcademicYear.Name))
                .ForMember(dest => dest.VariantName, opt => opt.MapFrom(src => src.Variant.Name))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.Name))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ReverseMap();

            CreateMap<Booklet, BookletCreateDTO>().ReverseMap();
            CreateMap<Booklet, BookletEditDTO>().ReverseMap();
        }
    }
}

