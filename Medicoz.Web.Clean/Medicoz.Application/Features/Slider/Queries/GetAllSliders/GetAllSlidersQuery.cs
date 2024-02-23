using MediatR;

namespace Medicoz.Application.Features.Slider.Queries.GetAllSliders
{
    public class GetAllSlidersQuery : IRequest<List<SliderListDTO>>
    {
    }
}
