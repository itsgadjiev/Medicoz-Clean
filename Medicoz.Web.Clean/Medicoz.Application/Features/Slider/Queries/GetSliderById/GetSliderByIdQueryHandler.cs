using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Slider.Commands.UpdateSlider;

namespace Medicoz.Application.Features.Slider.Queries.GetSliderById
{
    public class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, UpdateSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;

        public GetSliderByIdQueryHandler(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        public async Task<UpdateSliderCommand> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            await _sliderRepository.GetByIdAsync(request.Id);
            UpdateSliderCommand command = new UpdateSliderCommand();

            return command;
        }
    }
}
