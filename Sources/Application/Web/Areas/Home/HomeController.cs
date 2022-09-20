using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.Application.Areas.Home.Welcome;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Security;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Home;

[Route("home")]
[ApiController]
[Authorize(Policy = Policies.ApiWrite)]
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