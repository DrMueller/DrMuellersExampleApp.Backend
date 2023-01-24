using JetBrains.Annotations;
using Lamar;
using MediatR;

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

        this.AddMediatR(typeof(RegistryCollection));
    }
}