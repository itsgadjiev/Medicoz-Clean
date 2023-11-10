using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class SliderRepository : DatabaseLocalisationRepository<Slider>
    {
        private readonly AppDbContext _appDbContext;

        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


    }
}
