using AutoMapper;
using DTOLayer.DTOs.Text;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class TextProfile : Profile
    {
        public TextProfile()
        {
            CreateMap<Text, TextIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Text, TextCreateDTO>().ReverseMap();
            CreateMap<Text, TextEditDTO>().ReverseMap();
        }
    }
}
