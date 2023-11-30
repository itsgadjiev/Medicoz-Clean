using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }
}
