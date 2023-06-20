using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.Text;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Text
{
    public class TextEditDTOValidator : BaseFieldsValidator<TextEditDTO>
    {
        public TextEditDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Text))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Text))
                .MaximumLength(150).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Text, 150));

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Title))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Title))
                .Must(title => title.Contains("{0} – {1}")).WithMessage(String.Format(ValidationMessage.ContainsTextForTextTitle))
                .MaximumLength(500).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.Title, 500));

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Content))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.Content));
        }
    }
}
