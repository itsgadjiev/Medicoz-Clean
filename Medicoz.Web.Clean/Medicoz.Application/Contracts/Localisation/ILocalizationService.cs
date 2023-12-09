namespace Medicoz.Application.Contracts.Localisation
{
    public interface ILocalizationService<T> where T : class
    {
        string GetLocalizedValue(string entityId, string propertyName);
        void UpdateLocalizedValue(string entityId, string propertyName, string language, string newValue);
        Dictionary<string, string> GetAllEntitiesLocalizedValues(string propertyName);
        string GetLocalizedValueInsideView(T entity, string propertyName);

    }
}
