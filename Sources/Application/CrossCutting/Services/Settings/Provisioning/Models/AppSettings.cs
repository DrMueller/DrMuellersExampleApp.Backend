using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;

[PublicAPI]
public class AppSettings
{
    public const string SectionKey = "AppSettings";
    public string AppBasePath { get; set; } = null!;
    public string AppVersion { get; set; } = null!;

    public AzureAdSettings AzureAd { get; set; } = null!;
}