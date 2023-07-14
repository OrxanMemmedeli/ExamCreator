using AutoMapper;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Concrete;

namespace ExamCreator.AutoMapper
{
    public class PaymentSummaryProfile : Profile
    {
        public PaymentSummaryProfile()
        {
            CreateMap<PaymentSummary, PaymentSummaryCreateDTO>().ReverseMap();
            CreateMap<PaymentSummary, PaymentSummaryUpdateDTO>().ReverseMap();
        }
    }
}
