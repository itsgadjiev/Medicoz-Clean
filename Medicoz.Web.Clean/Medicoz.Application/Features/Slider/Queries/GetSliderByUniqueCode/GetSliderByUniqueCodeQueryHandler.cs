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

            return new UpdateSliderCommand();
;        }
    }
}
