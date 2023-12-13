using Medicoz.Application.Models.Identity;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registartionRequest);
        Task SignOut();

    }
}
