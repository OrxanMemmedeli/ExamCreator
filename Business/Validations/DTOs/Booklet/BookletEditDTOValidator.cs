using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Booklet;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Booklet
{
    public class BookletEditDTOValidator : BaseFieldsValidator<BookletEditDTO>
    {
        public BookletEditDTOValidator()
        {
            RuleFor(x => x.GradeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.GradeId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.GradeId));

            RuleFor(x => x.AcademicYearId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYearId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYearId));

            RuleFor(x => x.VariantId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.VariantId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.VariantId));

            RuleFor(x => x.ExamId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamId))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.ExamId));
        }
    }
}
