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
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Qrup"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Qrup"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Qrup", 50));
        }
    }
}
