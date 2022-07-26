using System.Security.Claims;
using MediatR;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.DrMuellersExampleApp.Domain.Areas.Users.Services;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LoginResultDto>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;
        private readonly IJwtTokenFactory _jwtTokenFactory;

        public LogInCommandHandler(
            IJwtTokenFactory jwtTokenFactory,
            IAppSettingsProvider appSettingsProvider)
        {
            _jwtTokenFactory = jwtTokenFactory;
            _appSettingsProvider = appSettingsProvider;
        }

        public Task<LoginResultDto> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var appSettings = _appSettingsProvider.Settings;
            if (appSettings.ApiPassword != request.Request.Password || appSettings.ApiUserName != request.Request.UserName)
            {
                return Task.FromResult(
                    new LoginResultDto
                    {
                        LoginSuccess = false
                    });
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Request.UserName) };
            var token = _jwtTokenFactory.CreateToken(claims);

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