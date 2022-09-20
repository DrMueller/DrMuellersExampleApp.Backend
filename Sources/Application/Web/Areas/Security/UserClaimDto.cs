using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Security;

[PublicAPI]
public class UserClaimDto
{
    public string Type { get; set; } = null!;
    public string Value { get; set; } = null!;
}