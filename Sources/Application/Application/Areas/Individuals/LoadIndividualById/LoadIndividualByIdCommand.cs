using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.LoadIndividualById;

public class LoadIndividualByIdCommand : ICommand<IndividualDto>
{
    public LoadIndividualByIdCommand(long id)
    {
        Id = id;
    }

    public long Id { get; }
}