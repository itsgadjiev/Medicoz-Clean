using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Slider.Queries.GetAllSliders
{
    public class GetAllSlidersQueryHandler : IRequestHandler<GetAllSlidersQuery, List<SliderListDTO>>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly ILocalizationService<Domain.Slider> _localizationService;

        public GetAllSlidersQueryHandler(ISliderRepository sliderRepository,ILocalizationService<Domain.Slider> localizationService)
        {
            _sliderRepository = sliderRepository;
            _localizationService = localizationService;
        }
        public async Task<List<SliderListDTO>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
        {
            var sliders = await _sliderRepository.GetAllAsync();
            var sliderListDto = sliders.Select(x => new SliderListDTO
            {
                Description = _localizationService.GetLocalizedValue(x.Id, nameof(x.Description)),
                Id = x.Id,
                Title = _localizationService.GetLocalizedValue(x.Id, nameof(x.Title))

            }).ToList();

            return sliderListDto;
        }
    }
}
