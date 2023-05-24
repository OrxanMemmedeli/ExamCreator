using DTOLayer.DTOs.Grade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.DTOs.Grade
{
    public class GradeCreateDTOValidator : AbstractValidator<GradeCreateDTO>
    {
        public GradeCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("olmaz").NotNull().WithMessage("olmaz");
        }
    }
}
