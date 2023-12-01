using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Interfaces.Persistence
{
    public interface IUserAuthenticationRepository
    {
        Task<string> Authenticate(UserLogin user);
    }
}
