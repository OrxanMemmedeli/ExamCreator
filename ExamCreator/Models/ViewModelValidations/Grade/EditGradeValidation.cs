using CoreLayer.Constants;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;
using FluentValidation;

namespace ExamCreator.Models.ViewModelValidations.Grade
{
    public class EditGradeValidation : AbstractValidator<EditGrade>
    {
        public EditGradeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .MaximumLength(25).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sinif", 25));

            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradılma Tarixi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradılma Tarixi"))
                .LessThanOrEqualTo(x => DateTime.Now).WithMessage(String.Format(ValidationMessage.LessThanOrEqualTo, "Yaradılma Tarixi", DateTime.Now.ToString("dd.MM.yyyy HH:mm")));

            RuleFor(x => x.ModifyedDate)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Dəyişiklik Tarixi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Dəyişiklik Tarixi"))
                .LessThanOrEqualTo(x => DateTime.Now).WithMessage(String.Format(ValidationMessage.LessThanOrEqualTo, "Dəyişiklik Tarixi", DateTime.Now.ToString("dd.MM.yyyy HH:mm")));

            RuleFor(x => x.CreatUserId)
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradan istifadəçi"))
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Yaradan istifadəçi"));

            //RuleFor(x => x.ModifyUserId)
            //    .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Düzəliş edən istifadəçi"))
            //    .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Düzəliş edən istifadəçi"));
        }
    }
}
