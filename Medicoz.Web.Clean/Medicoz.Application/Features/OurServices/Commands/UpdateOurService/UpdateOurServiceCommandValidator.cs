using FluentValidation;

namespace Medicoz.Application.Features.OurServices.Commands.UpdateOurService;

public class UpdateOurServiceCommandValidator : AbstractValidator<UpdateOurServiceCommand>
{
    public UpdateOurServiceCommandValidator()
    {
        RuleFor(content => content.Title)
            .NotNull()
            .NotEmpty();

        RuleForEach(dict => dict.Title.Values)
         .MinimumLength(3)
         .MaximumLength(200);

        RuleFor(content => content.Description)
          .NotNull()
          .NotEmpty();

        RuleForEach(dict => dict.Description.Values)
       .MinimumLength(3)
       .MaximumLength(200);

        RuleFor(content => content.Icon)
          .NotNull()
          .NotEmpty();

    }
}
