using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class OurService : BaseEntity
    {
        public string Icon { get; set; }
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }
    }
}
