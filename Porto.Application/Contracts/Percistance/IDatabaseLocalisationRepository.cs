namespace Medicoz.Application.Contracts.Percistance;

public interface IDatabaseLocalisationRepository
{
    string GetLocalizedString(string culture, string key);
}
