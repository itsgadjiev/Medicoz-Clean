﻿using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.OurServices.Commands.UpdateOurService
{
    public class UpdateOurServiceCommandHandler : IRequestHandler<UpdateOurServiceCommand, Unit>
    {
        private readonly IOurServicesRepository _ourServicesRepository;

        public UpdateOurServiceCommandHandler(IOurServicesRepository ourServicesRepository)
        {
            _ourServicesRepository = ourServicesRepository;
        }

        public async Task<Unit> Handle(UpdateOurServiceCommand request, CancellationToken cancellationToken)
        {

            var existingService = await _ourServicesRepository.GetByIdAsync(request.Id);

            if (existingService == null)
            {
                throw new NotFoundException("Service not found");
            }


            existingService.Title = request.Title;
            existingService.Description = request.Description;
            existingService.Icon = request.Icon;

            await _ourServicesRepository.UpdateAsync(existingService);

            return Unit.Value;
        }
    }
}
