using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Subject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Subject
{
    public class SubjectEditDTOValidator : BaseFieldsValidator<SubjectEditDTO>
    {
        public SubjectEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Fənn"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Fənn"))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, "Fənn", 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Fənn", 50));


            RuleFor(x => x.AmountForQuestion)
                .GreaterThanOrEqualTo(0).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, "Sual qiyməti", 0));
        }
    }
}
