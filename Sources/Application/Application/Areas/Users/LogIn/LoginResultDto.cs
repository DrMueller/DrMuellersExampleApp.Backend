using System.Security.Claims;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    public class LoginResultDto
    {
        public List<Claim> Claims { get; set; }
        public bool LoginSuccess { get; set; }
        public string Token { get; set; }
    }
}