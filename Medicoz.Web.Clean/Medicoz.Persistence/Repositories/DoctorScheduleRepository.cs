using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Medicoz.Persistence.Repositories;

public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
{
    public DoctorScheduleRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<List<DoctorSchedule>> GetDoctorSchedulesByDoctorIdAsync(int doctorId)
    {
        return await _context.DoctorSchedules.Where(x=>x.DoctorId == doctorId).ToListAsync();
    }

}
