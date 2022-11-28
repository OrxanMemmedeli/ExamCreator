using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;

namespace ExamCreator.AutoMapper
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, ListGrade>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Grade, CreateGrade>().ReverseMap();
            CreateMap<Grade, EditGrade>().ReverseMap();
        }
    }
}
