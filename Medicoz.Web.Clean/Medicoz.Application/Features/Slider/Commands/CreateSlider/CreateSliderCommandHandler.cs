using AutoMapper;
using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider;

public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, Unit>
{
    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;

    public CreateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
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

        var slider = new Domain.Slider
        {
            Title = new Dictionary<string, string>
            {
                 { LocalizationLanguages.AZ, request.TitleAZ },
                 { LocalizationLanguages.EN, request.TitleEN }
            },
            Description = new Dictionary<string, string>
            {
                  { LocalizationLanguages.AZ, request.DescAZ },
                  { LocalizationLanguages.EN, request.DescEN }
            },
            Quote = new Dictionary<string, string>
            {
                  { LocalizationLanguages.AZ, request.QuoteAZ },
                  { LocalizationLanguages.EN, request.QuoteEN }
            },
            ButtonName = new Dictionary<string, string>
            {
                  { LocalizationLanguages.AZ, request.BtnNameAZ1 },
                  { LocalizationLanguages.EN, request.BtnNameEN1 }
            },
            ButtonName2 = new Dictionary<string, string>
            {
                  { LocalizationLanguages.AZ, request.BtnNameAZ2 },
                  { LocalizationLanguages.EN, request.BtnNameEN2 }
            },
            Id=Guid.NewGuid().ToString(),
            ImageUrl = imgUrl,
            RedirectUrl = "google.com",
            RedirectUrl2 = "google.com"
        };
        await _sliderRepository.AddAsync(slider);
        await _sliderRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
