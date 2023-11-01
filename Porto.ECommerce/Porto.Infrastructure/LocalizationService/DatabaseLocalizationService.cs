using Medicoz.Application.Contracts.Localisation;
using Medicoz.Persistence.Repositories;

namespace Medicoz.Infrastructure.LocalizationService;

public class DatabaseLocalizationService : IDatabaseLocalizationService
{
    private readonly DatabaseLocalisationRepository _databaseLocalizationRepository;

    public DatabaseLocalizationService(DatabaseLocalisationRepository databaseLocalizationRepository)
    {
        _databaseLocalizationRepository = databaseLocalizationRepository;
    }

    public string GetLocalizedString(string culture, string key)
    {
        return _databaseLocalizationRepository.GetLocalizedString(culture, key);
    }
}
