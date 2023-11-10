using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Domain.Common.concrets;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Repositories;

public class DatabaseLocalisationRepository<T> : GenericRepository<T> , IDatabaseLocalisationRepository<T>
    where T : LocalizationEntry
{
    private readonly AppDbContext _appDbContext;

    public DatabaseLocalisationRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task<T> GetLocalizedEntity(string key)
    {
        var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        return await _appDbContext.Set<T>().FirstOrDefaultAsync(x=>x.Culture==culture);
           
    }

    public async Task<List<T>> GetLocalizedEntities(string key)
    {
        var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        return await _appDbContext.Set<T>().Where(x => x.Culture == culture).ToListAsync();
    }


}
