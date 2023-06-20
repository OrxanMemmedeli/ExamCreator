using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.QuestionType;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.QuestionType
{
    public class QuestionTypeEditDTOValidator : BaseFieldsValidator<QuestionTypeEditDTO>
    {
        public QuestionTypeEditDTOValidator()
        {
            RuleFor(x => x.ResponseType)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ResponseType))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ResponseType))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, EntityAndPropertyNames_Az.ResponseType, 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.ResponseType, 50));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Description))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Description))
                .MaximumLength(500).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Description, 500));

            RuleFor(x => x.ResponseCount)
                .GreaterThanOrEqualTo(0).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.ResponseCount, 0));
        }
    }
}
