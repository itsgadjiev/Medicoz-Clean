using Medicoz.Application.Contracts.Localisation;
using Medicoz.Domain.Common.concrets;
using Medicoz.Persistence.Database;

namespace Medicoz.Infrastructure.LocalizationService;

public class LocalizationService<T> : ILocalizationService<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public LocalizationService(AppDbContext context)
    {
        _context = context;
    }

    public string GetLocalizedValue(int entityId, string propertyName)
    {
        var language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        var entity = _context.Set<T>().Find(entityId);
        
        if (entity != null)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property != null)
            {
                var localizedData = property.GetValue(entity) as Dictionary<string, string>;
                if (localizedData != null && localizedData.ContainsKey(language))
                {
                    return localizedData[language];
                }
            }
        }

        return null;
    }

    public string GetLocalizedValueInsideView(T entity, string propertyName)
    {
        var language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

        if (entity != null)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property != null)
            {
                var localizedData = property.GetValue(entity) as Dictionary<string, string>;
                if (localizedData != null && localizedData.ContainsKey(language))
                {
                    return localizedData[language];
                }
            }
        }

        return null;
    }

    public Dictionary<int, string> GetAllEntitiesLocalizedValues(string propertyName)
    {
        var language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        var entities = _context.Set<T>().ToList();
        var result = new Dictionary<int, string>();

        foreach (var entity in entities)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property != null)
            {
                var localizedData = property.GetValue(entity) as Dictionary<string, string>;
                if (localizedData != null && localizedData.ContainsKey(language))
                {
                    result.Add((int)entity.GetType().GetProperty("Id").GetValue(entity), localizedData[language]);
                }
            }
        }

        return result;
    }

    public void UpdateLocalizedValue(int entityId, string propertyName, string language, string newValue)
    {
        var entity = _context.Set<T>().Find(entityId);
        if (entity != null)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property != null)
            {
                var localizedData = property.GetValue(entity) as Dictionary<string, string>;
                if (localizedData == null)
                {
                    localizedData = new Dictionary<string, string>();
                    property.SetValue(entity, localizedData);
                }

                localizedData[language] = newValue;
                _context.SaveChanges();
            }
        }
    }

    //public Dictionary<int, string> GetAllEntitiesLocalizedValues(string language)
    //{
    //    var entities = _context.Set<T>().ToList();
    //    var result = new Dictionary<int, string>();

    //    foreach (var entity in entities)
    //    {
    //        var properties = entity.GetType().GetProperties()
    //            .Where(prop => prop.PropertyType == typeof(Dictionary<string, string>));

    //        foreach (var property in properties)
    //        {
    //            var localizedData = property.GetValue(entity) as Dictionary<string, string>;
    //            if (localizedData != null && localizedData.ContainsKey(language))
    //            {
    //                result.Add((int)entity.GetType().GetProperty("Id").GetValue(entity), localizedData[language]);
    //                // This assumes that 'Id' is the property name for the entity ID
    //                // Modify 'Id' accordingly if it's different in your entity
    //                break; // Remove this line if you want to aggregate values from all properties
    //            }
    //        }
    //    }

    //    return result;
    //}
}
