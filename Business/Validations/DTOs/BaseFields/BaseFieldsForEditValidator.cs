using CoreLayer.Constants;
using CoreLayer.Utilities.GuidFormatControl;
using DTOLayer.DTOs.BaseFields;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.BaseFields
{
    public class BaseFieldsForEditValidator : AbstractValidator<BaseFieldsForEdit>
    {
        public BaseFieldsForEditValidator()
        {
            RuleFor(x => x.CreatedDate).Must(date => date >= DateTime.Now && date != null).WithMessage(ValidationMessage.DateTimeMinValue);

            //RuleFor(x => x.CreatUserId).Must(guid => GuidControl.BeValidGuidPattern(guid)).WithMessage(ValidationMessage.WrongGuidFormat);
        }
    }
}
