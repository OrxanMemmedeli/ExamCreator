using CoreLayer.Constants;
using DTOLayer.DTOs.ExamParameter;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.ExamParameter
{
    public class ExamParameterCreateDTOValidator : AbstractValidator<ExamParameterCreateDTO>
    {
        public ExamParameterCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameter))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameter))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.ExamParameter, 70));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Description))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Description))
                .MaximumLength(2500).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Description, 2500));

            RuleFor(x => x.SubjectCount)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectCount))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectCount))
                .GreaterThanOrEqualTo(1).WithMessage(String.Format(ValidationMessage.GreaterThanOrEqualTo, EntityAndPropertyNames_Az.SubjectCount, 1));
        }
    }
}
