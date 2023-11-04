using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class LocalizationEntry : BaseEntity 
    {
        public string Culture { get; set; } 
        public string Key { get; set; } 
    }
}
