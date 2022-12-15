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
    public class ExamParameterValidator : AbstractValidator<ExamParameter>
    {
        public ExamParameterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İmtahan Parametri"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İmtahan Parametri"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "İmtahan Parametri", 50));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Açıqlama"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Açıqlama"))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, "Açıqlama", 500));
        }
    }
}
