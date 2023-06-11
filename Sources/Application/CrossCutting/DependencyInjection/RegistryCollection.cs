using JetBrains.Annotations;
using Lamar;
using MediatR;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services.Implementation;

namespace Mmu.DrMuellersExampleApp.CrossCutting.DependencyInjection;

[UsedImplicitly]
public class RegistryCollection : ServiceRegistry
{
    public RegistryCollection()
    {
        Scan(
            scanner =>
            {
                scanner.AssemblyContainingType<RegistryCollection>();
                scanner.WithDefaultConventions();
            });
        
        // Mediator is also transient, needs to be the same
        For<IMediationService>().Use<MediationService>().Transient();
        this.AddMediatR(typeof(RegistryCollection));
    }
}