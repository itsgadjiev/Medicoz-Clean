using Medicoz.Application.Models.Identity;
using Medicoz.Identity.Models;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string userId);
        public string UserId { get; }
        Task<ApplicationUser> GetCurrentUserAsync();
    }
}
