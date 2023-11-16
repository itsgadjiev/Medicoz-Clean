using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public NavbarViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = new User();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userService.GetCurrentUserAsync();
            }
            return View(user);
        }
    }
}
