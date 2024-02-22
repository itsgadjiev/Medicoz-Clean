using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.MVC.ViewModels
{
    public class NavbarViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Basket Basket { get; set; }
    }
}
