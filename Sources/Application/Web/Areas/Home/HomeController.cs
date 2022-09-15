using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Mmu.DrMuellersExampleApp.Application.Areas.Home.Welcome;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Home;

[Route("home")]
[ApiController]
[Authorize]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class HomeController : ControllerBase
{
    private readonly IMediationService _mediator;

    public HomeController(IMediationService mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<WelcomeResultDto>> GetAsync()
    {
        var dto = await _mediator.SendAsync(new WelcomeCommand());

        return Ok(dto);
    }
}