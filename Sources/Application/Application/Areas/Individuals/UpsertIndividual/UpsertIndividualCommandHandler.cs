using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual;

public class UpsertIndividualCommandHandler : IRequestHandler<UpsertIndividualCommand, IndividualDto>
{
    private readonly Random _random = new();

    public Task<IndividualDto> Handle(UpsertIndividualCommand request, CancellationToken cancellationToken)
    {
#pragma warning disable CA5394 // Do not use insecure randomness
        request.Individual.Id = _random.Next(1000);
#pragma warning restore CA5394 // Do not use insecure randomness
        return Task.FromResult(request.Individual);
    }
}