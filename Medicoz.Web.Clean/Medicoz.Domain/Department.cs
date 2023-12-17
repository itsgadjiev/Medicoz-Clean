using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }
        public List<DoctorDepartment> DoctorDepartments { get; set; }
    }
}
