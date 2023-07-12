using AutoMapper;
using DTOLayer.DTOs.Company;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyIndexDTO>().ReverseMap();

            CreateMap<Company, CompanyCreateDTO>().ReverseMap();
            CreateMap<Company, CompanyEditDTO>().ReverseMap();
        }
    }
}
