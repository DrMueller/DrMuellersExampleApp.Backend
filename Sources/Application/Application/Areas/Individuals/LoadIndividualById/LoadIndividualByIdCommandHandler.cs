using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual
{
    public class LoadIndividualByIdCommandHandler : IRequestHandler<LoadIndividualByIdCommand, IndividualDto>
    {
        private Random _random = new Random();

        public Task<IndividualDto> Handle(LoadIndividualByIdCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(IndividualFactory.All.Single(f => f.ID == request.Id));
        }
    }
}