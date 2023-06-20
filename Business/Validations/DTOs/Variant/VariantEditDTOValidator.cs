using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Variant;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Variant
{
    public class VariantEditDTOValidator : BaseFieldsValidator<VariantEditDTO>
    {
        public VariantEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Variant))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Variant))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Variant, 50));
        }
    }
}
