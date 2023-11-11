using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Slider.Commands.UpdateSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Queries.GetSliderByUniqueCode
{
    public class GetSliderByUniqueCodeQueryHandler : IRequestHandler<GetSliderByUniqueCodeQuery, UpdateSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;

        public GetSliderByUniqueCodeQueryHandler(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task<UpdateSliderCommand> Handle(GetSliderByUniqueCodeQuery request, CancellationToken cancellationToken)
        {
            var sliders = await _sliderRepository.GetByUniqueCode(request.UniqueCode);

            UpdateSliderCommand updateSliderCommand =new UpdateSliderCommand();
            updateSliderCommand.EnglishContent = new();
            updateSliderCommand.AzerbaijaniContent = new();

            foreach (var slider in sliders)
            {
                if (slider.Culture == "az")
                {

                    updateSliderCommand.EnglishContent.Quote = slider.Quote;
                    updateSliderCommand.RedirectUrl1 = slider.RedirectUrl;
                    updateSliderCommand.RedirectUrl2 = slider.RedirectUrl2;
                    updateSliderCommand.AzerbaijaniContent.ButtonName1 = slider.ButtonName;
                    updateSliderCommand.AzerbaijaniContent.ButtonName2 = slider.ButtonName2;
                    updateSliderCommand.AzerbaijaniContent.Description = slider.Description;
                    updateSliderCommand.AzerbaijaniContent.Quote = slider.Quote;
                    updateSliderCommand.AzerbaijaniContent.Title = slider.Title;
                }

                if (slider.Culture == "en-US")
                {
                    updateSliderCommand.EnglishContent.Quote = slider.Quote;
                    updateSliderCommand.RedirectUrl1 = slider.RedirectUrl;
                    updateSliderCommand.RedirectUrl2 = slider.RedirectUrl2;
                    updateSliderCommand.EnglishContent.ButtonName1 = slider.ButtonName;
                    updateSliderCommand.EnglishContent.ButtonName2 = slider.ButtonName2;
                    updateSliderCommand.EnglishContent.Description = slider.Description;
                    updateSliderCommand.EnglishContent.Quote = slider.Quote;
                    updateSliderCommand.EnglishContent.Title = slider.Title;
                }
            }

            return updateSliderCommand;
        }
    }
}
