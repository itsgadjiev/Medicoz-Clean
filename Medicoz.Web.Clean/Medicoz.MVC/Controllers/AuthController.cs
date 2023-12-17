using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IAppLogger<AuthController> _appLogger;

        public AuthController(IAuthService authService, IUserService userService, IAppLogger<AuthController> appLogger)
        {
            _authService = authService;
            _userService = userService;
            _appLogger = appLogger;
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest model)
        {
            try
            {
                var response = await _authService.Login(model);
            }
            catch (NotFoundException e)
            {
                ModelState.AddModelError("", e.Value.ToString());
                return View(model);
                throw;
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LoggedAsync()
        {
            var user = await _userService.GetUserAsync(_userService.UserId);
            return View(user);
        }

        [HttpGet("OutAsync")]
        public async Task<IActionResult> OutAsync()
        {
            await _authService.SignOut();
            return RedirectToAction("Login");
        }
    }
}
