using Medicoz.Domain;

namespace Medicoz.Application.ViewModels.Areas.Admin
{
    public class DoctorListVMForAP
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Dictionary<string, string> Title { get; set; }
        public double Fee { get; set; }
    
    }
}
