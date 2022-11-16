using CoreLayer.Constants;
using EntityLayer.Concrete.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class BaseEntityValidator : AbstractValidator<BaseEntity>
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradılma Tarixi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradılma Tarixi"))
                .LessThanOrEqualTo(x => DateTime.Now).WithMessage(String.Format(ValidationMessage.LessThanOrEqualTo, "Yaradılma Tarixi", DateTime.Now.ToString("dd.MM.yyyy HH:mm")));

            RuleFor(x => x.ModifyedDate)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Dəyişiklik Tarixi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Dəyişiklik Tarixi"))
                .LessThanOrEqualTo(x => DateTime.Now).WithMessage(String.Format(ValidationMessage.LessThanOrEqualTo, "Dəyişiklik Tarixi", DateTime.Now.ToString("dd.MM.yyyy HH:mm")));

            RuleFor(x => x.CreatUserId)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradan istifadəçi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradan istifadəçi"));

            //RuleFor(x => x.ModifyUserId)
            //    .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Düzəliş edən istifadəçi"))
            //    .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Düzəliş edən istifadəçi"));
        }
    }
}
