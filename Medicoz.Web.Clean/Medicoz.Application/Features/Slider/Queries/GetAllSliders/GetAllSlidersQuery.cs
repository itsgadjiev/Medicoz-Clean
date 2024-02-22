using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Queries.GetAllSliders
{
    public class GetAllSlidersQuery : IRequest<List<SliderListDTO>>
    {
    }
}
