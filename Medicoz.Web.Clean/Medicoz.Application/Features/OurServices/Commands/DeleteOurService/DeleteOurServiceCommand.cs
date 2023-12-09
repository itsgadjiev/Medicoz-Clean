using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.OurServices.Commands.DeleteOurService;

public class DeleteOurServiceCommand : IRequest<Unit>
{
    public string Id { get; set; }
}
