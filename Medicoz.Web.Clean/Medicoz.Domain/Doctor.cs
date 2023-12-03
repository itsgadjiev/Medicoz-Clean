using Medicoz.Domain.Common;
using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain;

public class Doctor : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Dictionary<string, string> Title { get; set; }
    public Dictionary<string, string> Description { get; set; }
    public Dictionary<string, string> Education { get; set; }
    public Dictionary<string, string> Experience { get; set; }
    public double Fee { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ImageURL { get; set; }
    public List<DoctorSchedule> DoctorSchedules { get; set; }
    public List<DoctorReservation> DoctorReservations { get; set; }


}
