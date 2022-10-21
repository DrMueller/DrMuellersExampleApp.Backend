using MediatR;
using Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.LoadAllIndividuals;

public class LoadAllIndividualsCommand : ICommand<IReadOnlyCollection<IndividualDto>>, IRequest<IndividualDto>
{
}