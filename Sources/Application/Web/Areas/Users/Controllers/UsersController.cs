using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDddSimple.Application.Mediation.Services;
using Mmu.DrMuellersExampleApp.Application.Areas.Users.LogIn;

namespace Mmu.Mls3.WebApi.Infrastructure.Security.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediationService mediator;

        public UsersController(
            IMediationService mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> LoginAsync([FromBody] LoginRequestDto requestDto)
        {
            var loginResult = await mediator.SendAsync(new LogInCommand(requestDto));

            return Ok(loginResult);
        }
    }
}