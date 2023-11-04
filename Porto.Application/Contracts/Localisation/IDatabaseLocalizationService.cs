namespace Medicoz.Application.Contracts.Localisation;

public interface IDatabaseLocalizationService<T>
{
    Task<T> GetLocalizedEntity(string culture, string key);
}
