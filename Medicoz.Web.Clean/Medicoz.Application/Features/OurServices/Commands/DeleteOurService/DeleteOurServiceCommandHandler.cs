using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.OurServices.Commands.DeleteOurService;

public class DeleteOurServiceCommandHandler : IRequestHandler<DeleteOurServiceCommand, Unit>
{
    private readonly IOurServicesRepository _ourServicesRepository;

    public DeleteOurServiceCommandHandler(IOurServicesRepository ourServicesRepository)
    {
        _ourServicesRepository = ourServicesRepository;
    }
    public async Task<Unit> Handle(DeleteOurServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _ourServicesRepository.GetByIdAsync(request.Id);
        if (service == null) { throw new NotFoundException(); }

        await _ourServicesRepository.DeleteAsync(service);

        return Unit.Value;
    }
}
