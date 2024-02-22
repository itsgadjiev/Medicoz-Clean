using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommand : IRequest<Unit>
    {

        public string TitleAZ { get; set; }
        public string TitleEN{ get; set; }
        public string DescEN{ get; set; }
        public string DescAZ{ get; set; }
        public string QuoteAZ{ get; set; }
        public string QuoteEN{ get; set; }
        public string BtnNameEN1{ get; set; }
        public string BtnNameAZ1{ get; set; }
        public string BtnNameAZ2{ get; set; }
        public string BtnNameEN2{ get; set; }
        public IFormFile Image { get; set; }
        public string RedirectUrl1 { get; set; }
        public string RedirectUrl2 { get; set; }

    }

    
}
