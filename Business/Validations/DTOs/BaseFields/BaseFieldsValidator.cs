using CoreLayer.Constants;
using CoreLayer.Utilities.GuidFormatControl;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.BaseFields
{
    public class BaseFieldsValidator : AbstractValidator<DTOLayer.DTOs.BaseFields.BaseFields>
    {
        public BaseFieldsValidator()
        {
            RuleFor(x => x.Id).Must(GuidControl.BeValidGuidPattern).WithMessage(ValidationMessage.WrongGuidFormat);
            RuleFor(x => x.ModifyedDate).Must(date => date >= DateTime.Now).WithMessage(ValidationMessage.DateTimeMinValue);
        }
    }
}
