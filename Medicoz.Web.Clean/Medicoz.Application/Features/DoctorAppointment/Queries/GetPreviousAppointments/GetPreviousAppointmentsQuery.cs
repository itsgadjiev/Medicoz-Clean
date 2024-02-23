using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetPreviousAppointments
{
    public class GetPreviousAppointmentsQuery : IRequest<List<Domain.DoctorAppointment>>
    {
    }
}
