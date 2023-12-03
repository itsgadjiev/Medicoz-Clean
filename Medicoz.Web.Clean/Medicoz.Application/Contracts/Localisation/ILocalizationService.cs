namespace Medicoz.Application.Contracts.Localisation
{
    public interface ILocalizationService<T> where T : class
    {
        string GetLocalizedValue(int entityId, string propertyName);
        void UpdateLocalizedValue(int entityId, string propertyName, string language, string newValue);
        Dictionary<int, string> GetAllEntitiesLocalizedValues(string propertyName);
        string GetLocalizedValueInsideView(T entity, string propertyName);

    }
}
