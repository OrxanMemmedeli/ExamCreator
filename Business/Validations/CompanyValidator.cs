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
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Şirkət Adı"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Şirkət Adı"))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, "Şirkət Adı", 70));

            RuleFor(x => x.LogoUrl)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Logo"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Logo"));
        }
    }
}
