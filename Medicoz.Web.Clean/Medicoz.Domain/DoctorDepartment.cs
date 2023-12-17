using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class DoctorDepartment : BaseEntity
    {
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
