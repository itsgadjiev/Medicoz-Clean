using Medicoz.Application.Models.Identity;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetEmployees();
        Task<User> GetEmployee(string userId);
        User GetUser();
        public string UserId { get; }
    }
}
