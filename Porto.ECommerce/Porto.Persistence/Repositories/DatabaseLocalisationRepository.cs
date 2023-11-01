using Medicoz.Application.Contracts.Percistance;
using Medicoz.Persistence.Database;
namespace Medicoz.Persistence.Repositories;

public class DatabaseLocalisationRepository : IDatabaseLocalisationRepository
{
    private readonly AppDbContext _appDbContext;

    public DatabaseLocalisationRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public string GetLocalizedString(string culture, string key)
    {
        var localizedString = _appDbContext.LocalizationEntries
            .FirstOrDefault(e => e.Culture == culture && e.Key == key);

        return localizedString?.Value ?? key;
    }
}
