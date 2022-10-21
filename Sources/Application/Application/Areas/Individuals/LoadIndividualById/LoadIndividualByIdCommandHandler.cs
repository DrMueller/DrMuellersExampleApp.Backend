using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.LoadIndividualById;

public class LoadIndividualByIdCommandHandler : IRequestHandler<LoadIndividualByIdCommand, IndividualDto>
{
    public Task<IndividualDto> Handle(LoadIndividualByIdCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(IndividualFactory.All.Single(f => f.Id == request.Id));
    }
}