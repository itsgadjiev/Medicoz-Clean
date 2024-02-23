using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetTodayAppointments
{
    public class GetTodayAppointmentsQuery : IRequest<List<Domain.DoctorAppointment>>
    {
    }
}
