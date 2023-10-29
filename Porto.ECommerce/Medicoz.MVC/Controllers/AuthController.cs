using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;

namespace Medicoz.MVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public AuthController(IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;

        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest authRequest)
        {

            var authResponse = await _authService.Login(authRequest);
            if (authResponse != null)
            {
                return RedirectToAction("Logged","Auth");
            }
            return BadRequest();


        }

        public async Task<IActionResult> Logged()
        {
            
            var user = await _userService.GetEmployee(_userService.UserId);
            return View(user);
        }




    }
}
