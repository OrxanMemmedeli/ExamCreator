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
    public class BaseFieldsForEditValidator<T> : AbstractValidator<T> where T: BaseFieldsForEdit
    {
        public BaseFieldsForEditValidator()
        {
            Include(new BaseFieldsValidator<T>());
            RuleFor(x => x.CreatedDate).Must(date => date >= DateTime.Now.AddMinutes(-2) && date != null).WithMessage(ValidationMessage.DateTimeMinValue);

            //RuleFor(x => x.CreatUserId).Must(guid => GuidControl.BeValidGuidPattern(guid)).WithMessage(ValidationMessage.WrongGuidFormat);
        }
    }
}
