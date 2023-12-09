using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.Application.Features.DoctorAppointment.Commands
{
    public class MakeAnAppointmentCommand : IRequest<Unit>
    {
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }
        public string PasentId { get; set; }
        public string PasentName { get; set; }
        public string PasentPhone { get; set; }
        public string PasentEmail { get; set; }
        public string PasentNotes { get; set; }
        public string DoctorScheduleId { get; set; }
        public string DoctorId { get; set; }
    }
}
