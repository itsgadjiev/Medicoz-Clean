using AutoMapper;
using MediatR;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider;

public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, Unit>
{
    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CreateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService, IMapper mapper)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSliderCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new CustomValidationException(validationResult.Errors);
        }
        var imgUrl = _fileService.Upload(request.Image, "uploads/images");
        var uniquCode=Guid.NewGuid().ToString();

       


     

        return Unit.Value;
    }
}
