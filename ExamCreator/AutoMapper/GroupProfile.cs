using AutoMapper;
using DTOLayer.DTOs.Group;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Group, GroupCreateDTO>().ReverseMap();
            CreateMap<Group, GroupEditDTO>().ReverseMap();
        }
    }
}
