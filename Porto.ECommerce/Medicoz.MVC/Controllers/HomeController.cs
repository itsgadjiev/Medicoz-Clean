using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Localizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var local = _databaseStringLocalizer["Navbar"];
            var user = await _userService.GetEmployee(_userService.UserId);

            return View(user);
        }



    }
}