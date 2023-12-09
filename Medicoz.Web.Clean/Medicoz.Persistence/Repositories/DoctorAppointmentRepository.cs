using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Repositories;

public class DoctorAppointmentRepository : GenericRepository<DoctorAppointment>, IDoctorAppointmentRepository
{
    public DoctorAppointmentRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<List<DoctorAppointment>> GetAllReservedAppointmentsFromTodayByDoctorIdAsync(string doctorId)
    {
       return await _context.DoctorAppointment
            .Where(x => x.DoctorId == doctorId && x.ReservationDate > DateTime.Now)
            .Include(x=>x.DoctorSchedule)
            .ToListAsync();
    }

    public bool IsReserved(DateTime reservationDate, string doctorScheduleId)
    {
        if (_context.DoctorAppointment.Any(x => x.ReservationDate == reservationDate && x.DoctorScheduleId == doctorScheduleId))
        {
            return true;
        }
        return false;
    }
}
