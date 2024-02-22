using MediatR;
using Medicoz.Application.Features.Slider.Commands.UpdateSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Queries.GetSliderById
{
    public class GetSliderByIdQuery :IRequest<UpdateSliderCommand>
    {
        public string Id { get; set; }
    }
}
