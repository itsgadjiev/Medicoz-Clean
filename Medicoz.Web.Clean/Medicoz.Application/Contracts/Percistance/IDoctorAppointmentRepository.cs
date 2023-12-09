using Medicoz.Domain;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorAppointmentRepository : IGenericRepository<Domain.DoctorAppointment>
    {
        bool IsReserved(DateTime reservationDate, string doctorScheduleId);
        Task<List<Domain.DoctorAppointment>> GetAllReservedAppointmentsFromTodayByDoctorIdAsync(string doctorId);
    }
}
