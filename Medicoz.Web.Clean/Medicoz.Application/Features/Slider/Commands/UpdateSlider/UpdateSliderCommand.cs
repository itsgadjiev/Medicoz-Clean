using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Commands.UpdateSlider
{
    public class UpdateSliderCommand : IRequest<Unit>
    {
        public SliderContent EnglishContent { get; set; }
        public SliderContent AzerbaijaniContent { get; set; }
        public IFormFile Image { get; set; }
        public string RedirectUrl1 { get; set; }
        public string RedirectUrl2 { get; set; }
        public string UniqueCodeForLocalisation { get; set; }

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
}
