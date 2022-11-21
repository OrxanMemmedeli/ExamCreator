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
    public class UserTypeValidator : AbstractValidator<UserType>
    {
        public UserTypeValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İstifadəçi tipi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "İstifadəçi tipi"))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, "İstifadəçi tipi", 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "İstifadəçi tipi", 50));
        }
    }
}
