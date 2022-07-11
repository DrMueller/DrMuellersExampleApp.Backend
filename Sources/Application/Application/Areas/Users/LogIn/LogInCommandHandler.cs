using System.Security.Claims;
using MediatR;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.Mls3.WebApi.Infrastructure.Security.Services;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LoginResultDto>
    {
        private readonly IAppSettingsProvider appSettingsProvider;
        private readonly IJwtTokenFactory jwtTokenFactory;

        public LogInCommandHandler(
            IJwtTokenFactory jwtTokenFactory,
            IAppSettingsProvider appSettingsProvider)
        {
            this.jwtTokenFactory = jwtTokenFactory;
            this.appSettingsProvider = appSettingsProvider;
        }

        public Task<LoginResultDto> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var secSettings = appSettingsProvider.Settings.SecuritySettings;
            if (secSettings.Password != request.Request.Password || secSettings.UserName != request.Request.UserName)
            {
                return Task.FromResult(
                    new LoginResultDto
                    {
                        LoginSuccess = false
                    });
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Request.UserName) };
            var token = jwtTokenFactory.CreateToken(claims);

            return Task.FromResult(
                new LoginResultDto
                {
                    LoginSuccess = true,
                    Claims = claims,
                    Token = token
                });
        }
    }
}