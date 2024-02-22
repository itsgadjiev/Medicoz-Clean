using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;

        public NavbarViewComponent(IUserService userService, IBasketService basketService)
        {
            _userService = userService;
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavbarViewModel navbarViewModel = new NavbarViewModel();
            var user = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                navbarViewModel.ApplicationUser = await _userService.GetCurrentUserAsync();
            }
            navbarViewModel.Basket = await _basketService.GetBasketFromCookies(HttpContext);

            return View(navbarViewModel);
        }
    }
}
