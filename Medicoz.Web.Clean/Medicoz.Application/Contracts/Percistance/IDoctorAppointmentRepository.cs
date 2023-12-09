namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorAppointmentRepository : IGenericRepository<Domain.DoctorAppointment>
    {
        bool IsReserved(DateTime reservationDate, int doctorScheduleId);
        Task<List<Domain.DoctorAppointment>> GetAllReservedAppointmentsByDoctorId(string doctorId);
    }
}
