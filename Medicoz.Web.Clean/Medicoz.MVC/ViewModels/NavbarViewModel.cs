using Medicoz.Domain;
using Medicoz.Identity.Models;

namespace Medicoz.MVC.ViewModels
{
    public class NavbarViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Basket Basket{ get; set; }
    }
}
