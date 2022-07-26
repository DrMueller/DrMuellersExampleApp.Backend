using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mmu.DrMuellersExampleApp.Web.Areas.HealthCheck
{
    [AllowAnonymous]
    [Route("")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCheck()
        {
            return Ok();
        }
    }
}