using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual;

public class UpsertIndividualCommand : ICommand<IndividualDto>
{
    public UpsertIndividualCommand(IndividualDto individual)
    {
        Individual = individual;
    }

    public IndividualDto Individual { get; }
}