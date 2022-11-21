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
    public class ResponseValidator : AbstractValidator<Response>
    {
        public ResponseValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(20).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sual başlığı", 20));

            RuleFor(x => x.Title)
                .MaximumLength(800).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sual məzmunu", 800));


            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş fənn"));

            RuleFor(x => x.QuestionId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual"));

            RuleFor(x => x.QuestionTypeId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual tipi"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş sual tipi"));

            RuleFor(x => x.AcademicYearId)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş tədris ili"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Seçilmiş tədris ili"));
        }
    }
}
