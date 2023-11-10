using FluentValidation;

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
                .NotEmpty().WithMessage("Image is required.");
        }
    }

    public class SliderContentValidator : AbstractValidator<SliderContent>
    {
        public SliderContentValidator()
        {
            RuleFor(content => content.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(content => content.Description)
                .NotNull()
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(content => content.Quote)
                .NotNull()
                .NotEmpty().WithMessage("Quote is required.")
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(content => content.ButtonName1)
                .NotNull()
                .NotEmpty().WithMessage("ButtonName1 is required.")
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(content => content.ButtonName2)
                .NotNull()
                .NotEmpty().WithMessage("ButtonName2 is required.")
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(content => content.Quote)
                .NotNull()
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(5)
                .MaximumLength(300);



        }
    }
}
