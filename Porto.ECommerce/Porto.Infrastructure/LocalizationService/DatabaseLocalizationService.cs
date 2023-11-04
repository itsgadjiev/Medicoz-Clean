using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Persistence.Repositories;

namespace Medicoz.Infrastructure.LocalizationService;

public class DatabaseLocalizationService<T> /*: IDatabaseLocalizationService<T>*/
{
    //private readonly IDatabaseLocalisationRepository<T> _databaseLocalizationRepository;

    //public DatabaseLocalizationService(IDatabaseLocalisationRepository<T> databaseLocalizationRepository)
    //{
    //    _databaseLocalizationRepository = databaseLocalizationRepository;
    //}

    //public async Task<T> GetLocalizedString(string culture, string key)
    //{
    //    return await _databaseLocalizationRepository.GetLocalizedEntity(culture, key);
    //}
}
