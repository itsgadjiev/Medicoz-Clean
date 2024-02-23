using MediatR;
using Medicoz.Domain.Common.Enums;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetAppointments
{
    public class GetAppointmentsQuery : IRequest<List<Domain.DoctorAppointment>>
    {
        public string DoctorId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
