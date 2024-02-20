using FluentValidation;
using Medicoz.Application.Features.Products.Commands.AddCommand;

namespace Medicoz.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description).NotNull().WithMessage("Description is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
        }
    }
}
