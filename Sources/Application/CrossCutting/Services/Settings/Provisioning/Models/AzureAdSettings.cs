using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;

[PublicAPI]
public class AzureAdSettings
{
    public string Instance { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string TenantId { get; set; } = null!;
    public string Domain { get; set; } = null!;
}