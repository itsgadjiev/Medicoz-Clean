using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(command => command.EnglishContent)
                .SetValidator(new SliderContentValidator());

            RuleFor(command => command.AzerbaijaniContent)
                .SetValidator(new SliderContentValidator());

            RuleFor(x => x.Image)
             .NotNull()
             .WithMessage("Cant be null");

             RuleFor(x => x.Image)
             .Must(IsValidImage)
             .WithMessage("Not valid image");
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file != null)
            {
                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                {
                    return false;
                }
                if (file.Length > 2097152)
                {
                    return false;
                }
                return true;
            }
            return false;
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
