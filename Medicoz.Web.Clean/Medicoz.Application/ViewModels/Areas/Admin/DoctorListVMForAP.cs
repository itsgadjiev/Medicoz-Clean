using Medicoz.Domain;

namespace Medicoz.Application.ViewModels.Areas.Admin
{
    public class DoctorListVMForAP
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public double Fee { get; set; }
        public string ImageUrl { get; set; }

    }
}
