using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.DrMuellersExampleApp.Domain.Areas.Users.Services.Implementation
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        private readonly IAppSettingsProvider _appSettings;

        public JwtTokenFactory(IAppSettingsProvider appSettings)
        {
            _appSettings = appSettings;
        }

        public string CreateToken(IReadOnlyCollection<Claim> claims)
        {
            var signingKey = Encoding.ASCII.GetBytes(_appSettings.Settings.SecretKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.Now.AddYears(1),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            return token;
        }
    }
}