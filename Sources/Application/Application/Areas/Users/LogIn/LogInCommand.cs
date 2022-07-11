using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    public class LogInCommand : ICommand<LoginResultDto>
    {
        public LoginRequestDto Request { get; }

        public LogInCommand(LoginRequestDto request)
        {
            Request = request;
        }
    }
}