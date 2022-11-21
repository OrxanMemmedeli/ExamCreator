using CoreLayer.Constants;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sual mətni"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sual mətni"))
                .MaximumLength(15000).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sual mətni", 15000));

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"));


            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş bölmə"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş bölmə"));


            RuleFor(x => x.QuestionTypeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual tipi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual tipi"));


            RuleFor(x => x.QuestionLevelId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual səviyyəsi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual səviyyəsi"));


            RuleFor(x => x.GradeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sinif"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sinif"));


            RuleFor(x => x.AcademicYearId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş tədris ili"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş tədris ili"));
        }
    }
}
