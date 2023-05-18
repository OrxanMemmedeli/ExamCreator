using AutoMapper;
using DTOLayer.DTOs.UserType;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserType, UserTypeIndexDTO>();

            CreateMap<UserType, UserTypeCreateDTO>().ReverseMap();
            CreateMap<UserType, UserTypeEditDTO>().ReverseMap();
        }
    }
}
