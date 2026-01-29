using FluentValidation;
using Seyid.Business.Dtos.EmployeeDtos;
using Seyid.Business.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Validators.EmployeeValidators
{
    public class EmployeeUpdateDtoValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().MaximumLength(256).WithMessage("Maximum size 256 ola biler")
                .MinimumLength(3);

            RuleFor(x => x.Surname).NotEmpty().MaximumLength(256).WithMessage("Maximum size 256 ola biler")
                 .MinimumLength(3);


            RuleFor(x => x.Image)
            .Must(x => x?.CheckSize(2) ?? true).WithMessage("Image maximum size must be 2 mb")
              .Must(x => x?.CheckType("image") ?? true).WithMessage("You can only upload with image format");
        }
    }
}
