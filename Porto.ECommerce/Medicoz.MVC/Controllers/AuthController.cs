using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest authRequest)
        {
            await _authService.Login(authRequest);

            return Ok(authRequest);
        }




    }
}
