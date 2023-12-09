using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Repositories;

public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
{
    public DoctorScheduleRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<List<DoctorSchedule>> GetDoctorSchedulesByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorSchedules.Where(x => x.DoctorId == doctorId).OrderBy(x=>x.DayOfWeek).OrderBy(x=>x.StartTime).ToListAsync();
    }

    public async Task<string> GetDoctorScheduleByStartAndEndTimeAsync(DateTime reservationDate, string doctorId)
    {

        var doctorSchedule = await _context.DoctorSchedules
           .Where(x => x.DoctorId == doctorId &&
           x.DayOfWeek == reservationDate.DayOfWeek &&
           x.StartTime.TimeOfDay == reservationDate.TimeOfDay)
           .FirstOrDefaultAsync();

        if (doctorSchedule is null) return null;

        return doctorSchedule.Id;
    }

}
