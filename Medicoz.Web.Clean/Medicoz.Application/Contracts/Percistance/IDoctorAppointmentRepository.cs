using Medicoz.Domain;
using Medicoz.Domain.Common.Enums;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorAppointmentRepository : IGenericRepository<Domain.DoctorAppointment>
    {
        bool IsReserved(DateTime reservationDate, string doctorScheduleId);
        Task<List<Domain.DoctorAppointment>> GetAppointmentsFromTodayByStatus(string doctorEmail, AppointmentStatus appointmentStatus);
        Task<List<DoctorAppointment>> GetAppointmentsByStatusForToday(string doctorEmail, AppointmentStatus appointmentStatus);
        Task<List<DoctorAppointment>> GetPreviousAppointmentsByStatus(string doctorEmail, AppointmentStatus appointmentStatus);
        Task<List<Domain.DoctorAppointment>> GetAllReservedAppointmentsFromTodayByDoctorIdAsync(string doctorId);
    }
}
