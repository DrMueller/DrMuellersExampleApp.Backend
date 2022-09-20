using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Security;

[Route("security")]
[ApiController]
[Authorize]
public class SecurityController : ControllerBase
{
    [HttpGet("users/current/claims")]
    public ActionResult<UserClaimsDto> GetCurrentUserClaims()
    {
        var claims = Request.HttpContext.User.Claims.Select(claim => new UserClaimDto
        {
            Type = claim.Type,
            Value = claim.Value
        }).ToList();

        return Ok(new UserClaimsDto
        {
            UserClaims = claims
        });
    }
}