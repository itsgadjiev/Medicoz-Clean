using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.OurServices.Commands.AddOurService
{
    public class AddOurServiceCommandValidator : AbstractValidator<AddOurServiceCommand>
    {
        public AddOurServiceCommandValidator()
        {
            RuleFor(content => content.TitleEn)
                .NotEmpty().WithMessage("Icon is required.")
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(content => content.TitleAz)
               .NotEmpty().WithMessage("Icon is required.")
               .NotNull().WithMessage("Icon is required.")
               .MinimumLength(2)
               .MaximumLength(100);

            RuleFor(content => content.Icon)
              .NotEmpty().WithMessage("Icon is required.")
              .NotNull().WithMessage("Icon is required.")
              .MinimumLength(2)
              .MaximumLength(100);

            RuleFor(content => content.DescriptionEn)
             .NotEmpty().WithMessage("Icon is required.")
             .NotNull().WithMessage("Icon is required.")
             .MinimumLength(2)
             .MaximumLength(100);

            RuleFor(content => content.DescriptionAz)
              .NotEmpty().WithMessage("Icon is required.")
              .NotNull().WithMessage("Icon is required.")
              .MinimumLength(2)
              .MaximumLength(100);
        }
    }
}
