using System.Security.Claims;
using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    [PublicAPI]
    public class LoginResultDto
    {
        public List<Claim> Claims { get; set; } = null!;
        public bool LoginSuccess { get; set; }
        public string Token { get; set; } = null!;
    }
}