using Medicoz.Domain.Common.concrets;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.Domain
{
    public class DoctorAppointment : BaseEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorScheduleId { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }
        public string PasentId { get; set; }
        public string PasentName { get; set; }
        public string PasentPhone { get; set; }
        public string PasentEmail { get; set; }
        public string PasentNotes { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
    }
}
