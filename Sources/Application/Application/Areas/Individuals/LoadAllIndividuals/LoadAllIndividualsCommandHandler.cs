using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.LoadAllIndividuals
{
    public class LoadAllIndividualsCommandHandler : IRequestHandler<LoadAllIndividualsCommand, IReadOnlyCollection<IndividualDto>>
    {
        public Task<IReadOnlyCollection<IndividualDto>> Handle(LoadAllIndividualsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(IndividualFactory.All);
        }
    }
}
