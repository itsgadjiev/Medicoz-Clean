using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;

namespace Medicoz.Application.Features.OurServices.Commands.AddOurService
{
    public class AddOurServiceCommandHandler : IRequestHandler<AddOurServiceCommand, Unit>
    {
        private readonly IOurServicesRepository _ourServicesRepository;

        public AddOurServiceCommandHandler(IOurServicesRepository ourServicesRepository)
        {
            _ourServicesRepository = ourServicesRepository;
        }
        public async Task<Unit> Handle(AddOurServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddOurServiceCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var service = new OurService
            {
                Title = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.TitleAz },
                    { LocalizationLanguages.EN, request.TitleEn }
                },
                Description = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.DescriptionAz },
                    { LocalizationLanguages.EN, request.DescriptionEn }
                },
                Icon = request.Icon,
            };


            await _ourServicesRepository.AddAsync(service);
            return Unit.Value;

        }
    }
}
