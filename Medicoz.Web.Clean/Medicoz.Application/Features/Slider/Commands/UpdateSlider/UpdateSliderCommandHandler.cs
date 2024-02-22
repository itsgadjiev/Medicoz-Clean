using MediatR;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;

namespace Medicoz.Application.Features.Slider.Commands.UpdateSlider
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, Unit>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IFileService _fileService;

        public UpdateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
        {
            _sliderRepository = sliderRepository;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            
            return Unit.Value;
        }

       

    }
}
