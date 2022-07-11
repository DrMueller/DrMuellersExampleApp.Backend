using Microsoft.Extensions.Options;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _settings;
        public AppSettings Settings => _settings.Value;

        public AppSettingsProvider(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
    }
}