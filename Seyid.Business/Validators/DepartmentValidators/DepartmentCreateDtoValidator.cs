using FluentValidation;
using Seyid.Business.Dtos.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Validators.DepartmentValidators
{
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().MaximumLength(256).WithMessage("Maximum size 256 ola biler")
               .MinimumLength(3);
        }
    }
}
