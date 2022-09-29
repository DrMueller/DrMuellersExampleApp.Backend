using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.DrMuellersExampleApp.Web.Areas.HealthCheck;

[AllowAnonymous]
[Route("")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly IAppSettingsProvider _appsSettingsProvider;

    public HealthCheckController(IAppSettingsProvider appsSettingsProvider)
    {
        _appsSettingsProvider = appsSettingsProvider;
    }

    [HttpGet]
    public IActionResult GetCheck()
    {
        return Ok();
    }

    [HttpGet("settings")]
    public ActionResult<AppSettings> GetAppSettings()
    {
        return Ok(_appsSettingsProvider.Settings);
    }
}