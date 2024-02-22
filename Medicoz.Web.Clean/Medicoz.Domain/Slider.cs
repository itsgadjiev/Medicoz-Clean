using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class Slider : BaseEntity
    {
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }
        public Dictionary<string, string> Quote { get; set; }
        public Dictionary<string, string> ButtonName { get; set; }
        public Dictionary<string, string> ButtonName2 { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectUrl2 { get; set; }
        public string ImageUrl { get; set; }


    }
}
