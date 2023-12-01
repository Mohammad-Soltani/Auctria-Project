using AuctriaProject.Application.Models;

namespace AuctriaProject.Application.Interfaces.Services
{
    public interface IUserAuthenticationService
    {
        Task<string> Authenticate(UserLoginViewModel user);
    }
}
