using AuctriaProject.Application.Interfaces.Persistence;
using AuctriaProject.Domain.Entities;
using AuctriaProject.Infrastructure.Interfaces;
using AuctriaProject.Infrastructure.SQL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuctriaProject.Infrastructure.Repositories
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly ISharedContext _sharedContext;
        private readonly IConfiguration _configuration;
        public UserAuthenticationRepository(ISharedContext sharedContext, IConfiguration configuration)
        {
            _sharedContext = sharedContext;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(UserLogin user)
        {
            var loggedInUser = await _sharedContext.QueryAsync<User>(Queries.GetUserRole, new
                                                 {
                                                     userName = user.UserName, password = user.Password
                                                 }); 

            if (loggedInUser.Any())
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.First().UserName),
                    new Claim(ClaimTypes.Role, loggedInUser.First().Role)
                };

                var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(20),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                                                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty)), SecurityAlgorithms.HmacSha256)
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }
            else
                return null;
        }
    }
}
