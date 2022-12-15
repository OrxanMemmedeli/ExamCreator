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
    public class TextValidator : AbstractValidator<Text>
    {
        public TextValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Mətn adı"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Mətn adı"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Mətn adı", 50));

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Başlıq"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Başlıq"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Başlıq", 50));

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Məzmun"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Məzmun"));
        }
    }
}
