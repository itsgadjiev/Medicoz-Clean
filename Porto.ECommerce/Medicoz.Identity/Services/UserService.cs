using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
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

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<User> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new User
            {
                Email = employee.Email,
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            };
        }

        public async Task<List<User>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new User
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }

        public User GetUser()
        {
            return new User { Firstname = "slaak" };
        }

            //    var subClaim = JwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "sub"); // subject claim
            //    var emailClaim = claims.FirstOrDefault(claim => claim.Type == "email");
            //    var uidClaim = claims.FirstOrDefault(claim => claim.Type == "uid");
            //    var roleClaim = claims.FirstOrDefault(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            //    var expClaim = claims.FirstOrDefault(claim => claim.Type == "exp");
            //    var issClaim = claims.FirstOrDefault(claim => claim.Type == "iss");
            //    var audClaim = claims.FirstOrDefault(claim => claim.Type == "aud");
            //    // You can add more claims as needed

            //    return new User
            //    {
            //        Id = userId,
            //        Firstname = userName,
            //        Email = userEmail
            //    };
            //}
        }
}
