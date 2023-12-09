using MediatR;
using Medicoz.Application.Features.OurServices.Commands.UpdateOurService;

namespace Medicoz.Application.Features.OurServices.Queries.GetOurServices
{
    public class GetOurServiceByIdQuery : IRequest<UpdateOurServiceCommand>
    {
        public string Id { get; set; }
    }
}
