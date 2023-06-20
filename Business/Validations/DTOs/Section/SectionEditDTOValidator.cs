using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Section;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Section
{
    public class SectionEditDTOValidator : BaseFieldsValidator<SectionEditDTO>
    {
        public SectionEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Section))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Section))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, EntityAndPropertyNames_Az.Section, 3))
                .MaximumLength(250).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Section, 250));

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectId));
        }
    }
}
