using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Contracts.Localisation
{
    public interface ILocalizationService<T> where T : class
    {
        string GetLocalizedValue(int entityId, string propertyName, string language);
        void UpdateLocalizedValue(int entityId, string propertyName, string language, string newValue);
        Dictionary<int, string> GetAllEntitiesLocalizedValues(string propertyName, string language);
        Dictionary<int, string> GetAllEntitiesLocalizedValues(string language);
    }
}
