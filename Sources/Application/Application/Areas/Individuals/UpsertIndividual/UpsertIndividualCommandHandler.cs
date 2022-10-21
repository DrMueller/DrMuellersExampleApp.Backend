using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual
{
    public class UpsertIndividualCommandHandler : IRequestHandler<UpsertIndividualCommand, IndividualDto>
    {
        private Random _random = new Random();

        public Task<IndividualDto> Handle(UpsertIndividualCommand request, CancellationToken cancellationToken)
        {
            request.Individual.ID = _random.Next(1000);
            return Task.FromResult(request.Individual);
        }
    }
}