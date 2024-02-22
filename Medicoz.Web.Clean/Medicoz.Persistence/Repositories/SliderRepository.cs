using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Medicoz.Persistence.Repositories
{
    public class SliderRepository : GenericRepository<Slider> , ISliderRepository
    {
        private readonly AppDbContext _appDbContext;

        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        


    }
}
