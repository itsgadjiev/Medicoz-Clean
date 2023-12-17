using Medicoz.Application.Contracts.Identity;
using Medicoz.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Medicoz.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId => _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public async Task<ApplicationUser> GetUserAsync(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            if (employee is null) { throw new Exception("User is not authenticated"); }
            return employee;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var employee = await _userManager.FindByIdAsync(UserId);
            if (employee is null) { throw new Exception("User is not authenticated"); }
            return employee;
        }
    }
}
