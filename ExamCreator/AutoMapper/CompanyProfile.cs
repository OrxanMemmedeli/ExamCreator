using AutoMapper;
using DTOLayer.DTOs.Company;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyIndexDTO>()
                .ForMember(dest => dest.ModifyUserName, opt => opt.MapFrom(src => src.ModifyUser.UserName)).ReverseMap();

            CreateMap<Company, CompanyCreateDTO>().ReverseMap();
            CreateMap<Company, CompanyEditDTO>().ReverseMap();
        }
    }
}
