using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.MVC.ViewModels
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public List<Slider> Sliders { get; set; }
        public Dictionary<string,string> EntitiesLocalizedValuesTitle { get; set; }
        public Dictionary<string,string> EntitiesLocalizedValuesDesc { get; set; }
        public List<OurService> OurServices { get; set; }
        public List<Doctor> Doctors { get; set; }

    }
}
