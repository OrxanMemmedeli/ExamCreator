using CoreLayer.Constants;
using EntityLayer.Concrete;
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
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İmtahan"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İmtahan"))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, "İmtahan", 70));
        }
    }
}
