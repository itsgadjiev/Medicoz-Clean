using Medicoz.Domain.Common.concrets;
using Medicoz.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicoz.Domain
{
    public class DoctorAppointment : BaseEntity
    {
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorScheduleId { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }
        public string PasentId { get; set; }
        public string PasentName { get; set; }
        public string PasentPhone { get; set; }
        public string PasentEmail { get; set; }
        public string PasentNotes { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
