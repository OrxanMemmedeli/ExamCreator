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
    public class QuestionLevelValidator : AbstractValidator<QuestionLevel>
    {
        public QuestionLevelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sual səviyyəsi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sual səviyyəsi"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sual səviyyəsi", 50));

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Səviyə qiyməti"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Səviyyə qiyməti"))
                .InclusiveBetween((short)1, (short)5).WithMessage(String.Format(ValidationMessage.InclusiveBetween, 1, 5));
        }
    }
}
