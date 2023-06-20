using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.SubjectParameter;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.SubjectParameter
{
    public class SubjectParameterEditDTOValidator : BaseFieldsValidator<SubjectParameterEditDTO>
    {
        public SubjectParameterEditDTOValidator()
        {
            RuleFor(x => x.QuestionCount)
                  .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionCount))
                  .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionCount))
                  .GreaterThanOrEqualTo(1).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.QuestionCount, 1));

            RuleFor(x => x.Order)
                  .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Order))
                  .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Order))
                  .GreaterThanOrEqualTo(1).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.Order, 1));

            RuleFor(x => x.ExamParameterId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameterId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameterId));
        }
    }
}
