using Medicoz.Application.Contracts.Localisation;
using Microsoft.Extensions.Localization;

namespace Medicoz.Application.Localizer;

public class DatabaseStringLocalizer : IStringLocalizer
{

    private readonly IDatabaseLocalizationService _localizationService;

    public DatabaseStringLocalizer(IDatabaseLocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public LocalizedString this[string name]
    {
        get
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var localizedString = _localizationService.GetLocalizedString(culture, name);
            return new LocalizedString(name, localizedString);
        }
    }

    public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        throw new NotImplementedException();
    }
}
