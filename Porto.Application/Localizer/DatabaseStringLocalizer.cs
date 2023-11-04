using Medicoz.Application.Contracts.Localisation;
using Microsoft.Extensions.Localization;

namespace Medicoz.Application.Localizer;

public class DatabaseStringLocalizer<T> : IStringLocalizer
{

    private readonly IDatabaseLocalizationService<T> _localizationService;

    public DatabaseStringLocalizer(IDatabaseLocalizationService<T> localizationService)
    {
        _localizationService = localizationService;
    }

    public LocalizedString this[string name]
    {
        get
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var localizedEntity = _localizationService.GetLocalizedEntity(culture, name);
            return new LocalizedString(name, localizedEntity.ToString());
        }
    }

    public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        throw new NotImplementedException();
    }
}
