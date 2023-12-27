using FluentValidation;
using Medicoz.Application.Common.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommandValidator :AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator()
        {
            RuleFor(x=>x.Image).NotNull().NotEmpty();
            RuleFor(x => x.Image)
            .MustAsync(async (image, cancellationToken) => await IsValidImage.Handle(image))
            .WithMessage("Invalid image format or URL.");

            RuleFor(x => x.DetailAZ)
                .NotEmpty().WithMessage("DetailAZ is required.")
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(x => x.DetailEN)
                .NotEmpty().WithMessage("DetailEN is required.")
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(x => x.NameEN)
                .NotEmpty().WithMessage("NameEN is required.")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.NameAZ)
                .NotEmpty().WithMessage("NameAZ is required.")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.Icon)
                .NotNull()
                .NotEmpty().WithMessage("Icon is required.");
              
        }
    }
}
