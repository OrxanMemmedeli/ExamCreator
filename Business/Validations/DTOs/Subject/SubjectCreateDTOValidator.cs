using CoreLayer.Constants;
using DTOLayer.DTOs.Subject;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Subject
{
    public class SubjectCreateDTOValidator : AbstractValidator<SubjectCreateDTO>
    {
        public SubjectCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Subject))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Subject))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, EntityAndPropertyNames_Az.Subject, 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Subject, 50));


            RuleFor(x => x.AmountForQuestion)
                .GreaterThanOrEqualTo(0).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.AmountForQuestion, 0));
        }
    }
}
