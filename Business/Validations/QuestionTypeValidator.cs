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
    public class QuestionTypeValidator : AbstractValidator<QuestionType>
    {
        public QuestionTypeValidator()
        {
            RuleFor(x => x.ResponseType)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Cavab tipi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Cavab tipi"))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, "Cavab tipi", 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Cavab tipi", 50));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Açıqlama"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Açıqlama"))
                .MaximumLength(500).WithMessage(String.Format(ValidationMessage.MaximumLength, "Açıqlama", 500));
        }
    }
}
