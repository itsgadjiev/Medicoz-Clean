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

        Domain.Slider azerbaijaniSlider = new Domain.Slider
        {
            ButtonName = request.AzerbaijaniContent.ButtonName1,
            ButtonName2 = request.AzerbaijaniContent.ButtonName2,
            Culture = "az",
            Description = request.AzerbaijaniContent.Description,
            Quote = request.AzerbaijaniContent.Quote,
            Title = request.AzerbaijaniContent.Title,
            ImageUrl = imgUrl,
            RedirectUrl = request.RedirectUrl1,
            RedirectUrl2 = request.RedirectUrl2,
            UniqueCodeForLocalisation = uniquCode
        };

        Domain.Slider englishSlider = new Domain.Slider
        {
            ButtonName = request.EnglishContent.ButtonName1,
            ButtonName2 = request.EnglishContent.ButtonName2,
            Culture = "en-US",
            Description = request.EnglishContent.Description,
            Quote = request.EnglishContent.Quote,
            Title = request.EnglishContent.Title,
            ImageUrl = imgUrl,
            RedirectUrl = request.RedirectUrl1,
            RedirectUrl2 = request.RedirectUrl2,
            UniqueCodeForLocalisation = uniquCode
        };


        await _sliderRepository.AddAsync(englishSlider);
        await _sliderRepository.AddAsync(azerbaijaniSlider);

        return Unit.Value;
    }
}
