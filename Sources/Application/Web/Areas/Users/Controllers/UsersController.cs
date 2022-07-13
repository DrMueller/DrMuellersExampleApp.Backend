using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Users.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediationService _mediator;

        public UsersController(
            IMediationService mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> LoginAsync([FromBody] LoginRequestDto requestDto)
        {
            var loginResult = await _mediator.SendAsync(new LogInCommand(requestDto));

            return Ok(loginResult);
        }

        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello from Web API");
        }

    }
}