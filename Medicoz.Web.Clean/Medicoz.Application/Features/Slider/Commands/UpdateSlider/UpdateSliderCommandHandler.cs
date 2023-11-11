using MediatR;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;

namespace Medicoz.Application.Features.Slider.Commands.UpdateSlider
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, Unit>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IFileService _fileService;

        public UpdateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
        {
            _sliderRepository = sliderRepository;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var sliders = await _sliderRepository.GetByUniqueCode(request.UniqueCodeForLocalisation);
            string filename = string.Empty;
            if (request.Image != null)
                filename = _fileService.Upload(request.Image, "images/uploads");

            foreach (var slider in sliders)
            {

                if (slider.Culture == "az")
                {
                    UpdateSliderWithAzerbaijaniContent(slider, request.AzerbaijaniContent, request);
                    if (!String.IsNullOrEmpty(filename)) { slider.ImageUrl = filename; }

                }
                else if (slider.Culture == "en-US")
                {
                    UpdateSliderWithEnglishContent(slider, request.EnglishContent, request);
                    if (!String.IsNullOrEmpty(filename)) { slider.ImageUrl = filename; }
                }

                await _sliderRepository.UpdateAsync(slider);
            }
            return Unit.Value;
        }

        private void UpdateSliderWithAzerbaijaniContent(Domain.Slider slider, UpdateSliderCommand.SliderContent azerbaijaniContent, UpdateSliderCommand request)
        {
            slider.Quote = azerbaijaniContent.Quote;
            slider.RedirectUrl = request.RedirectUrl1;
            slider.RedirectUrl2 = request.RedirectUrl2;
            slider.ButtonName = azerbaijaniContent.ButtonName1;
            slider.ButtonName2 = azerbaijaniContent.ButtonName2;
            slider.Description = azerbaijaniContent.Description;
            slider.Title = azerbaijaniContent.Title;
        }

        private void UpdateSliderWithEnglishContent(Domain.Slider slider, UpdateSliderCommand.SliderContent englishContent, UpdateSliderCommand request)
        {
            slider.Quote = englishContent.Quote;
            slider.RedirectUrl = request.RedirectUrl1;
            slider.RedirectUrl2 = request.RedirectUrl2;
            slider.ButtonName = englishContent.ButtonName1;
            slider.ButtonName2 = englishContent.ButtonName2;
            slider.Description = englishContent.Description;
            slider.Title = englishContent.Title;
        }

    }
}
