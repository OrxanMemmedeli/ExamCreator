﻿using CoreLayer.Constants;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class GradeValidator : AbstractValidator<Grade>
    {
        public GradeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, "Sinif"))
                .MaximumLength(25).WithMessage(String.Format(ValidationMessage.MaximumLength, "Sinif", 25));
        }
    }
}
