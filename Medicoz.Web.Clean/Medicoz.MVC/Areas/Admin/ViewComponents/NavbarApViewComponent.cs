using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.ViewComponents
{
    public class NavbarApViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public NavbarApViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userService.GetCurrentUserAsync();
            }
            else
            {
                user.FirstName = "Hele login olmamisham yetm";
            }
            return View(user);
        }
    }
}
