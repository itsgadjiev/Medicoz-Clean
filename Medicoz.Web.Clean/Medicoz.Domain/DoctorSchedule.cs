using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class DoctorSchedule : BaseEntity
    {
        public string DoctorId { get; set; }
        //public Dictionary<string, DayOfWeek> DayOfWeek { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Doctor Doctor { get; set; }
        public bool IsReserved { get; set; }
        public string ReservingUserID { get; set; }
        public List<DoctorAppointment> DoctorReservations { get; set; }
    }
}
