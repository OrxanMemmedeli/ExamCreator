using CoreLayer.Constants;
using DTOLayer.DTOs.Response;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Response
{
    public class ResponseCreateDTOValidator : AbstractValidator<ResponseCreateDTO>
    {
        public ResponseCreateDTOValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(20).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.ResponseTitle, 20));

            RuleFor(x => x.Content)
                .MaximumLength(800).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.ResponseContent, 800));

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.SubjectId));

            RuleFor(x => x.QuestionId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionId));

            RuleFor(x => x.QuestionTypeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionTypeId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.QuestionTypeId));

            RuleFor(x => x.AcademicYearId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYearId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYearId));
        }
    }
}
