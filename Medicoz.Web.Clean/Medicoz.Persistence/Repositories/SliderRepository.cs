using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Medicoz.Persistence.Repositories
{
    public class SliderRepository : DatabaseLocalisationRepository<Slider> , ISliderRepository
    {
        private readonly AppDbContext _appDbContext;

        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Slider>> GetByUniqueCode(string code)
        {
            return await _appDbContext.Set<Slider>().Where(x => x.UniqueCodeForLocalisation == code).ToListAsync();
        }


    }
}
