using System.Security.Claims;

namespace Mmu.DrMuellersExampleApp.Domain.Areas.Users.Services
{
    public interface IJwtTokenFactory
    {
        string CreateToken(IReadOnlyCollection<Claim> claims);
    }
}