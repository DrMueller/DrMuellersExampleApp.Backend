namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    public class LoginRequestDto
    {
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}