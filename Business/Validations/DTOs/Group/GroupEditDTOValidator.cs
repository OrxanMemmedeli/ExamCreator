using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Group;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Group
{
    public class GroupEditDTOValidator : BaseFieldsValidator<GroupEditDTO>
    {
        public GroupEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Group))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Group))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Group, 50));
        }
    }
}
