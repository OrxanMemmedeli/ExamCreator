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
    public class AcademicYearValidator : AbstractValidator<AcademicYear>
    {
        public AcademicYearValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Tədris ili", 50));
        }
    }
}
