using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.OurServices.Commands.UpdateOurService;

namespace Medicoz.Application.Features.OurServices.Queries.GetOurServices;

public class GetOurServiceByIdQueryHandler : IRequestHandler<GetOurServiceByIdQuery, UpdateOurServiceCommand>
{
    private readonly IOurServicesRepository _ourServicesRepository;

    public GetOurServiceByIdQueryHandler(IOurServicesRepository ourServicesRepository)
    {
        _ourServicesRepository = ourServicesRepository;
    }

    public async Task<UpdateOurServiceCommand> Handle(GetOurServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _ourServicesRepository.GetByIdAsync(request.Id);
        if (service is null) throw new NotFoundException(service);

        var viewModel = new UpdateOurServiceCommand
        {
            Id = service.Id,
            Title = service.Title,
            Description = service.Description,
            Icon = service.Icon
        };

        return viewModel;
    }
}
