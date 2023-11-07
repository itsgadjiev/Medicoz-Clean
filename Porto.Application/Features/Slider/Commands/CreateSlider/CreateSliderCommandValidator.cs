using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(command => command.EnglishContent)
                .SetValidator(new SliderContentValidator());

            RuleFor(command => command.FrenchContent)
                .SetValidator(new SliderContentValidator());

            RuleFor(command => command.Image)
                .NotEmpty().WithMessage("Image URL is required.");
        }
    }

    public class SliderContentValidator : AbstractValidator<SliderContent>
    {
        public SliderContentValidator()
        {
            RuleFor(content => content.Title)
                .NotEmpty().WithMessage("Title is required.");


        }
    }
}
