using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories;

public class DoctorAppointmentRepository : GenericRepository<DoctorAppointment>, IDoctorAppointmentRepository
{
    public DoctorAppointmentRepository(AppDbContext context) : base(context)
    {

    }

    public bool IsReserved(DateTime reservationDate,int doctorScheduleId)
    {
        if (_context.DoctorAppointment.Any(x=>x.ReservationDate == reservationDate && x.DoctorScheduleId == doctorScheduleId))
        {
            return true;
        }
        return false;
    }
}
