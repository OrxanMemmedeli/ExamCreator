using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Company;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Company
{
    public class CompanyEditDTOValidator : BaseFieldsValidator<CompanyEditDTO>
    {
        public CompanyEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Company))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Company))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Company, 50));

            RuleFor(x => x.LogoUrl)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Logo))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Logo))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Logo, 50));
        }
    }
}
