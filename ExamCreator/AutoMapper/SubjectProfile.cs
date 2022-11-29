using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Subject;

namespace ExamCreator.AutoMapper
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, ListSubject>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName));

            CreateMap<Subject, CreateSubject>().ReverseMap();
            CreateMap<Subject, EditSubject>().ReverseMap();
        }
    }
}
