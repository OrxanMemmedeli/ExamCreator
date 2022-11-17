using CoreLayer.Constants;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;
using FluentValidation;

namespace ExamCreator.Models.ViewModelValidations.Grade
{
    public class CreateGradeValidation : AbstractValidator<CreateGrade>
    {
        public CreateGradeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .MaximumLength(25).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sinif", 25));
        }
    }
}
