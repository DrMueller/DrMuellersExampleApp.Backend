using Microsoft.AspNetCore.Mvc;

namespace Mmu.DrMuellersExampleApp.Web.Areas.HealthCheck
{
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
