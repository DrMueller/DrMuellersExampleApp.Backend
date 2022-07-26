using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.Application.Areas.Pictures.GetUserPicture;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Pictures
{
    [Route("pictures")]
    [ApiController]
    [Authorize]
    public class PicturesController : ControllerBase
    {
        private readonly IMediationService _mediator;

        public PicturesController(IMediationService mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserPictureResultDto>> GetAsync()
        {
            var dto = await _mediator.SendAsync(new GetUserPictureCommand());

            return Ok(dto);
        }
    }
}