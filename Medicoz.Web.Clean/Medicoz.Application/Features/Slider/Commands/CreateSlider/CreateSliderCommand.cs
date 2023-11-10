using MediatR;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommand : IRequest<Unit>
    {
        public SliderContent EnglishContent { get; set; }
        public SliderContent FrenchContent { get; set; }
        public IFormFile Image { get; set; }
        public string RedirectUrl1 { get; set; }
        public string RedirectUrl2 { get; set; }

    }

    public class SliderContent
    {
        public string Culture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public string ButtonName1 { get; set; }
        public string ButtonName2 { get; set; }
    }
}
