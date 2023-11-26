using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class DoctorSchedule : BaseEntity
    {
        public int DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Doctor Doctor { get; set; }
    }
}
