using Medicoz.Application.Models.Identity;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string userId);
        public string UserId { get; }
        Task<ApplicationUser> GetCurrentUserAsync();
    }
}
