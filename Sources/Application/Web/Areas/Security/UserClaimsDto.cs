using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Security;

[PublicAPI]
public class UserClaimsDto
{
    public List<UserClaimDto> UserClaims { get; set; } = null!;
}