using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {

            RuleFor(content => content.TitleAZ)
                .NotNull().WithMessage("TitleEN is required.")
               .NotEmpty().WithMessage("TitleAZ is required.")
               .MinimumLength(2)
               .MaximumLength(100);

            RuleFor(content => content.TitleEN)
               .NotNull().WithMessage("TitleEN is required.")
               .NotEmpty().WithMessage("TitleEN is required.")
               .MinimumLength(2)
               .MaximumLength(100);

            RuleFor(content => content.DescAZ)
              .NotNull().WithMessage("DescAZ is required.")
              .NotEmpty().WithMessage("DescAZ is required.")
              .MinimumLength(2)
              .MaximumLength(100);

            RuleFor(content => content.DescEN)
             .NotNull().WithMessage("DescEN is required.")
             .NotEmpty().WithMessage("DescEN is required.")
             .MinimumLength(2)
             .MaximumLength(100);

            RuleFor(content => content.QuoteEN)
              .NotNull().WithMessage("QuoteENon is required.")
              .NotEmpty().WithMessage("QuoteEN is required.")
              .MinimumLength(2)
              .MaximumLength(100);

            RuleFor(content => content.QuoteAZ)
              .NotEmpty().WithMessage("Icon is required.")
              .NotNull().WithMessage("Icon is required.")
              .MinimumLength(2)
              .MaximumLength(100);
        }
    }
}
