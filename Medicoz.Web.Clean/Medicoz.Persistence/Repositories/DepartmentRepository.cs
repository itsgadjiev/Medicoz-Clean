using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}
