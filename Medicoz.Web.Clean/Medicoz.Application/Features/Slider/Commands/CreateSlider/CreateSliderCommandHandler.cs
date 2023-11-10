using MediatR;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider;

public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, Unit>
{
    //private readonly SliderRepository _sliderRepository;

    //public CreateSliderCommandHandler(SliderRepository sliderRepository)
    //{
    //    _sliderRepository = sliderRepository;
    //}
    public async Task<Unit> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
    //    var validator = new CreateSliderCommandValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    //if (!validationResult.IsValid)
    //    //{
    //    //    throw new ValidationException(validationResult.Errors);
    //    //}
    //    //fileService
    //    //request.Image.SaveFile

       return Unit.Value;
    }
}
