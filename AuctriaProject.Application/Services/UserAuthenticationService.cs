using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Interfaces.Persistence;
using AutoMapper;
using AuctriaProject.Application.Models;
using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly IMapper _mapper;
        public UserAuthenticationService(IUserAuthenticationRepository userAuthenticationRepository, IMapper mapper)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _mapper = mapper;
        }
        public async Task<string> Authenticate(UserLoginViewModel user)
        {
            var entityModel = _mapper.Map<UserLogin>(user);
            return await _userAuthenticationRepository.Authenticate(entityModel);
        }
    }
}
