using CoreLayer.Constants;
using EntityLayer.Concrete;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Exam))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Exam))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Exam, 70));
        }
    }
}
