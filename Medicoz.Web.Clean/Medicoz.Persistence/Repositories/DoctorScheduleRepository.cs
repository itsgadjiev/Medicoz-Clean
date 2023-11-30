using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories;

public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
{
    public DoctorScheduleRepository(AppDbContext context) : base(context)
    {
    }
}
