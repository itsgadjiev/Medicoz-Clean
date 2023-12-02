using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Models;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetEmployeesAsync();
        Task<ApplicationUser> GetEmployeeAsync(string userId);
        public string UserId { get; }
        Task<ApplicationUser> GetCurrentUserAsync();
    }
}
