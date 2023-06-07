using CoreLayer.Constants;
using DTOLayer.DTOs.AcademicYear;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.AcademicYear
{
    public class AcademicYearEditDTOValidator : AbstractValidator<AcademicYearEditDTO>
    {
        public AcademicYearEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Tədris ili", 50));

            RuleFor(x => x.)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Tədris ili"))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, "Tədris ili", 50));
        }
    }
}
