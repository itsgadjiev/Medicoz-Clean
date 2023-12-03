namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorAppointmentRepository : IGenericRepository<Domain.DoctorAppointment>
    {
        bool IsReserved(DateTime reservationDate, int doctorScheduleId);
    }
}
