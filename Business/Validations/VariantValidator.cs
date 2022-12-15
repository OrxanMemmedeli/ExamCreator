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
    public class VariantValidator : AbstractValidator<Variant>
    {
        public VariantValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Variant"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Variant"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Variant", 50));
        }
    }
}
