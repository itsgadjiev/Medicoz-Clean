using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Persistence.Repositories;

namespace Medicoz.Infrastructure.LocalizationService;

public class DatabaseLocalizationService : IDatabaseLocalizationService
{
    private readonly IDatabaseLocalisationRepository _databaseLocalizationRepository;

    public DatabaseLocalizationService(IDatabaseLocalisationRepository databaseLocalizationRepository)
    {
        _databaseLocalizationRepository = databaseLocalizationRepository;
    }

    public string GetLocalizedString(string culture, string key)
    {
        return _databaseLocalizationRepository.GetLocalizedString(culture, key);
    }
}
