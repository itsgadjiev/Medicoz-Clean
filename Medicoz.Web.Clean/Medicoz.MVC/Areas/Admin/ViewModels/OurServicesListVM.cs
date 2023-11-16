using Medicoz.Domain;

namespace Medicoz.MVC.Areas.Admin.ViewModels
{
    public class OurServicesListVM
    {
        public List<OurService> OurServices { get; set; }
        public Dictionary<int,string> Title { get; set; }
        public Dictionary<int,string> Desc { get; set; }
    }
}
