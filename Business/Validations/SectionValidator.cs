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
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Bölmə"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Bölmə"))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, "Bölmə", 3))
                .MaximumLength(250).WithMessage(String.Format(ValidationMessage.MaximumLength, "Bölmə", 250));

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"));
        }
    }
}
