﻿using Business.Validations.DTOs.BaseFields;
using CoreLayer.Constants;
using DTOLayer.DTOs.UserType;
using EntityLayer.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.UserType
{
    public class UserTypeEditDTOValidator : BaseFieldsValidator<UserTypeEditDTO>
    {
        public UserTypeEditDTOValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.UserType))
                .NotNull().WithMessage(String.Format(ValidationMessage.NotEmptyAndNotNull, EntityAndPropertyNames_Az.AcademicYear))
                .MinimumLength(3).WithMessage(String.Format(ValidationMessage.MinimumLength, EntityAndPropertyNames_Az.AcademicYear, 3))
                .MaximumLength(50).WithMessage(String.Format(ValidationMessage.MaximumLength, EntityAndPropertyNames_Az.AcademicYear, 50));
        }
    }
}
