using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.LoadAllIndividuals;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Security;

namespace Mmu.DrMuellersExampleApp.Web.Areas.Individuals
{
    [Route("individuals")]
    [ApiController]
    [Authorize(Policy = Policies.ApiWrite)]
    public class IndividualsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndividualsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualDto>>> GetOverviewAsync()
        {
            var dtos = await this._mediator.Send(new LoadAllIndividualsCommand());
            return Ok(dtos);
        }

        [HttpGet("{individualId:long}")]
        public async Task<ActionResult<IndividualDto>> LoadByIdAsync(long individualId)
        {
            var dto = await this._mediator.Send(new LoadIndividualByIdCommand(individualId));
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult<IndividualDto>> UpsertAsync(IndividualDto dto)
        {
            var newDto = await this._mediator.Send(new UpsertIndividualCommand(dto));
            return Ok(newDto);
        }
    }
}
