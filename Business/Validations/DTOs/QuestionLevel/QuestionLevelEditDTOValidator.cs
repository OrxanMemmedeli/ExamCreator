using CoreLayer.Constants;
using DTOLayer.DTOs.QuestionLevel;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.QuestionLevel
{
    public class QuestionLevelEditDTOValidator : AbstractValidator<QuestionLevelEditDTO>
    {
        public QuestionLevelEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionLevelName))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionLevelName))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.QuestionLevelName, 50));

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionLevel))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionLevel))
                .InclusiveBetween((short)1, (short)5).WithMessage(String.Format(ValidationMessage.InclusiveBetween, 1, 5));
        }
    }
}
