using Medicoz.Application.Features.Slider.Queries.GetAllSliders;
using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.MVC.ViewModels
{
    public class HomeViewModel
    {
        public ApplicationUser User { get; set; }
        public Dictionary<string, string> EntitiesLocalizedValuesTitle { get; set; }
        public Dictionary<string, string> EntitiesLocalizedValuesDesc { get; set; }
        public List<OurService> OurServices { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<SliderListDTO> SliderListDTOs{ get; set; }

    }
}
