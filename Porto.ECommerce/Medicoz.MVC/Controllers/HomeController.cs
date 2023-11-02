using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Localizer;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly DatabaseStringLocalizer _databaseStringLocalizer;

        public HomeController(IUserService userService, DatabaseStringLocalizer databaseStringLocalizer)
        {
            _userService = userService;
            _databaseStringLocalizer = databaseStringLocalizer;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            var user = await _userService.GetEmployeeAsync(_userService.UserId);
            

            HomeViewModel homeViewModel = new HomeViewModel
            {
                User = user,
            };

            return View(homeViewModel);
        }



    }
}