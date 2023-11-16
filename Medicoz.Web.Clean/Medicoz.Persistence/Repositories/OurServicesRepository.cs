using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class OurServicesRepository : GenericRepository<OurService>, IOurServicesRepository
    {
        public OurServicesRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

    }
}
