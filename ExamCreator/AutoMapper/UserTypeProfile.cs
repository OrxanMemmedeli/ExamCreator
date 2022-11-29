using AutoMapper;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.UserType;

namespace ExamCreator.AutoMapper
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserType, ListUserType>();

            CreateMap<UserType, CreateUserType>().ReverseMap();
            CreateMap<UserType, EditUserType>().ReverseMap();
        }
    }
}
