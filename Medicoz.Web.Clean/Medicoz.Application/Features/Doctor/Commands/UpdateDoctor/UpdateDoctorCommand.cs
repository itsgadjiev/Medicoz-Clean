using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.Application.Features.Doctor.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<Unit>
    {
        public string DoctorId { get; set; }
        public string TitleAz { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }
        public string EducationAz { get; set; }
        public string EducationEn { get; set; }
        public string ExperienceAz { get; set; }
        public string ExperienceEn { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IFormFile Image { get; set; }
        public double Fee { get; set; }
        public DoctorScheduleForUpdateDoctorCommand DoctorScheduleForUpdateDoctorCommand { get; set; }
        public string WebRootPath { get; set; }

    }

    public class DoctorScheduleForUpdateDoctorCommand
    {
        public DayOfWeek[] WorkingDaysOfDoctor { get; set; }
        public Domain.Doctor Doctor { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
