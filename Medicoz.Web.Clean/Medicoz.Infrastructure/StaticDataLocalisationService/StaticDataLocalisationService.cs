using Medicoz.Application.Contracts.Localisation;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Infrastructure.StaticDataLocalisationService
{
    public class StaticDataLocalisationService<T> : IStaticDataLocalisationService<T> 
        where T : LocalizedStaticEntity
    {
        private readonly AppDbContext _appDbContext;

        public StaticDataLocalisationService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string GetLocalizedValue(string key)
        {
            var language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var entity = _appDbContext.Set<T>().FirstOrDefault(x=>x.Key == key);

            if (entity != null)
            {
                var property = entity.GetType().GetProperty("Value");
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
    }
}
