using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
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
        public async Task<ApplicationUser> GetEmployeeAsync(string userId)
        {

            var employee = await _userManager.FindByIdAsync(userId);
            if (employee is null) { throw new Exception("User is not authenticated"); }

            var role = await _userManager.GetRolesAsync(employee);
            return new ApplicationUser
            {
                Email = employee.Email,
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FirstRoleName = role.FirstOrDefault(),
            };
        }

        public async Task<List<ApplicationUser>> GetEmployeesAsync()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new ApplicationUser
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName,
                FirstRoleName= q.FirstRoleName,
                
            }).ToList();
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var employee = await _userManager.FindByIdAsync(UserId);
            if (employee is null) { throw new Exception("User is not authenticated"); }
            var role = await _userManager.GetRolesAsync(employee);

            return new ApplicationUser
            {
                Id = employee.Id,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FirstRoleName = role.FirstOrDefault(),
            };
        }
    }
}
