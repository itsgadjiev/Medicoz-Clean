using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Models;
using Medicoz.Persistence.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public string UserId => _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
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

        //public async Task<User> GetUserAsync()
        //{

        //    var userClaimId = _contextAccessor.HttpContext?.User.FindFirst("uid");
        //    if (userClaimId is null)
        //    {
        //        throw new Exception("User is not authenticated");
        //    }

        //    var userClaimIdInt = (userClaimId.Value).ToString();
        //    ApplicationUser user = await _userManager.FindByIdAsync(userClaimIdInt);

        //    if (user is null)
        //    {
        //        throw new Exception("User is not found");
        //    }

        //    User needUser = new User
        //    {
        //        Email = user.Email,
        //        Id = user.Id,
        //        Firstname= user.FirstName,
        //        Lastname= user.LastName
        //    };

        //    return needUser;
        //}

       
    }
}
