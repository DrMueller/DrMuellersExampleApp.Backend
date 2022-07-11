using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}