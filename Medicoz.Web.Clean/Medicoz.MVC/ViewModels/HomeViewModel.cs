using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.MVC.ViewModels
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public List<Slider> Sliders { get; set; }
        public Dictionary<int,string> EntitiesLocalizedValuesTitle { get; set; }
        public Dictionary<int,string> EntitiesLocalizedValuesDesc { get; set; }
        public List<TestModel> TestModels { get; set; }

    }
}
