using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppLogger<HomeController> _appLogger;
        private readonly IUserService _userService;

        public HomeController(IAppLogger<HomeController> appLogger,IUserService userService)
        {
            _appLogger = appLogger;
            _userService = userService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userService.GetEmployee(_userService.UserId);
            return View(user);
        }



    }
}