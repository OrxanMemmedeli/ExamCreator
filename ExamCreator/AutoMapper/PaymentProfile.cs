using AutoMapper;
using DTOLayer.DTOs.Payment;
using EntityLayer.Concrete.ExceptionalEntities;

namespace ExamCreator.AutoMapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
        }
    }
}
