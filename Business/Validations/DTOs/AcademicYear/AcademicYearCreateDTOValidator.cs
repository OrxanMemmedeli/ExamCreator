﻿using CoreLayer.Constants;
using DTOLayer.DTOs.AcademicYear;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.AcademicYear
{
    public class AcademicYearCreateDTOValidator : AbstractValidator<AcademicYearCreateDTO>
    {
        public AcademicYearCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYear))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYear))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.AcademicYear, 50));
        }
    }
}
