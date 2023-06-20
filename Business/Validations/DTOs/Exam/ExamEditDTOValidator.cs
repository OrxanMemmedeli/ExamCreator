using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Exam;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Exam
{
    public class ExamEditDTOValidator : BaseFieldsValidator<ExamEditDTO>
    {
        public ExamEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Exam))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Exam))
                .MaximumLength(70).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Exam, 70));

            RuleFor(x => x.GradeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.GradeId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.GradeId));

            RuleFor(x => x.ExamParameterId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameterId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamParameterId));
        }
    }
}
