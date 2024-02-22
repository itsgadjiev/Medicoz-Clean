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
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }
        public Dictionary<string, string> Quote { get; set; }
        public Dictionary<string, string> ButtonName { get; set; }
        public Dictionary<string, string> ButtonName2 { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectUrl2 { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile NewImage{ get; set; }

    }
}
