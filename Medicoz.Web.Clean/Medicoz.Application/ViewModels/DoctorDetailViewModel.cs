using Medicoz.Application.Features.DoctorAppointment.Commands;
using Medicoz.Domain;

namespace Medicoz.Application.ViewModels
{
    public class DoctorDetailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public double Fee { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnMonday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnTuesday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnWednesday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnThursday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnFriday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnSaturday { get; set; }
        public List<DoctorSchedule> DoctorSchedulesOnSunday { get; set; }
        public List<DoctorSchedule> AllDoctorSchedules { get; set; }
        public List<DoctorAppointment> ReservedDoctorAppointments { get; set; }
        public MakeAnAppointmentCommand MakeAnAppointmentCommand { get; set; }
        public List<DoctorDepartmentViewModel> DoctorDepartmentViewModels { get; set; }

        public List<string> NamesDeps { get; set; }

    }

    public class DoctorDepartmentViewModel
    {
        public string Name{ get; set; }
        public Department Department{ get; set; }
    }


}
