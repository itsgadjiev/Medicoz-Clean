namespace Medicoz.Application.Contracts.Localisation;

public interface IDatabaseLocalizationService
{
    string GetLocalizedString(string culture, string key);
}
