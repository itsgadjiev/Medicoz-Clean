using MediatR;
using Medicoz.Application.Constants;

namespace Medicoz.Application.Features.OurServices.Commands.UpdateOurService
{
    public class UpdateOurServiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }
        public string Icon { get; set; }
    }
}
