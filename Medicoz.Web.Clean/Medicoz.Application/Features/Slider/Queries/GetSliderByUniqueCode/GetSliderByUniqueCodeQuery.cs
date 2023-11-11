using MediatR;
using Medicoz.Application.Features.Slider.Commands.UpdateSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Queries.GetSliderByUniqueCode
{
    public class GetSliderByUniqueCodeQuery : IRequest<UpdateSliderCommand>
    {
        public string UniqueCode { get; set; }
    }
}
