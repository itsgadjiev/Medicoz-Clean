using Medicoz.Application.Contracts.Percistance;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class LocalizedStaticEntityRepository : GenericRepository<Domain.LocalizedStaticEntity>, ILocalizedStaticEntityRepository
    {
        public LocalizedStaticEntityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
