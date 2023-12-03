using Medicoz.Application.Features.DoctorAppointment.Commands;
using Medicoz.Domain;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.MVC.ViewModels
{
    public class DoctorDetailViewModel
    {
        public int Id { get; set; }
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
        public List<DoctorSchedule> DoctorSchedules { get; set; }
        public MakeAnAppointmentCommand MakeAnAppointmentCommand { get; set; }

    }
}
