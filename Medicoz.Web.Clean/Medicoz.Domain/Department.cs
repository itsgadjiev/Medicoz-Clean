using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class Department : BaseEntity
    {
        public Dictionary<string,string> Name { get; set; }
        public Dictionary<string, string> Detail { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }
        public List<DoctorDepartment> DoctorDepartments { get; set; }
    }
}
