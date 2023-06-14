using CoreLayer.Constants;
using DTOLayer.DTOs.QuestionParameter;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.QuestionParameter
{
    public class QuestionParameterEditDTOValidator : AbstractValidator<QuestionParameterEditDTO>
    {
        public QuestionParameterEditDTOValidator()
        {
            RuleFor(x => x.StartQuestionNumber)
                  .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.StartQuestionNumber))
                  .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.StartQuestionNumber))
                  .GreaterThanOrEqualTo(1).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.SubjectCount, 1));

            RuleFor(x => x.EndQuestionNumber)
                  .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.EndQuestionNumber))
                  .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.EndQuestionNumber))
                  //.GreaterThanOrEqualTo(x => x.StartQuestionNumber).WithMessage((a, EndQuestionNumber) => String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.EndQuestionNumber, a.StartQuestionNumber))
                  //.GreaterThanOrEqualTo(x => x.StartQuestionNumber).WithMessage((x, StartQuestionNumber) => String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.EndQuestionNumber, StartQuestionNumber))
                  .GreaterThanOrEqualTo(x => x.StartQuestionNumber).WithMessage(x => String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.EndQuestionNumber, x.StartQuestionNumber));
            
            RuleFor(x => x.QuestionTypeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionTypeId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionTypeId));

            RuleFor(x => x.SubjectParameterId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectParameterId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectParameterId));
        }
    }
}
