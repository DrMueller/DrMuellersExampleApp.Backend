using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Home.Welcome;

[PublicAPI]
public class WelcomeResultDto
{
    public string AppVersion { get; set; } = null!;
}