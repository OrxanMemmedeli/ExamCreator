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
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Fənn"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Fənn"))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, "Fənn", 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Fənn", 50));
        }
    }
}
