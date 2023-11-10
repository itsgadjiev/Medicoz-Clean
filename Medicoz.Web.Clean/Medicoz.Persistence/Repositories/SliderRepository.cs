using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class SliderRepository : DatabaseLocalisationRepository<Slider> , ISliderRepository
    {
        private readonly AppDbContext _appDbContext;

        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


    }
}
