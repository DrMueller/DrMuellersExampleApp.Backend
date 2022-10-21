using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.UpsertIndividual
{
    public class LoadIndividualByIdCommand : ICommand<IndividualDto>
    {
        public long Id { get; }

        public LoadIndividualByIdCommand(long id)
        {
            Id = id;
        }

    }
}
