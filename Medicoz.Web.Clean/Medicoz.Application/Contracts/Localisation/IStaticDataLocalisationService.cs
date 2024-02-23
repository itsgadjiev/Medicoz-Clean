using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Contracts.Localisation
{
    public interface IStaticDataLocalisationService<T>
    {
        string GetLocalizedValue(string key);
        string GetLocalizedValueInsideView(T entity, string propertyName);

    }
}
