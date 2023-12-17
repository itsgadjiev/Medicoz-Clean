using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories;

public class DoctorDepartmentRepository : GenericRepository<DoctorDepartment>, IDoctorDepartmentRepository
{
    public DoctorDepartmentRepository(AppDbContext context) : base(context)
    {
    }
}
