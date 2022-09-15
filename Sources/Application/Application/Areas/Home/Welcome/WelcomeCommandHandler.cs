using MediatR;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Home.Welcome;

public class WelcomeCommandHandler : IRequestHandler<WelcomeCommand, WelcomeResultDto>
{
    private readonly IAppSettingsProvider _appSettingsProvidrer;

    public WelcomeCommandHandler(IAppSettingsProvider appSettingsProvidrer)
    {
        _appSettingsProvidrer = appSettingsProvidrer;
    }

    public Task<WelcomeResultDto> Handle(WelcomeCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new WelcomeResultDto
        {
            AppVersion = _appSettingsProvidrer.Settings.AppVersion
        });
    }
}