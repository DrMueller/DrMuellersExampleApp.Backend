using JetBrains.Annotations;
using Lamar;
using Lamar.Scanning.Conventions;
using MediatR;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.CrossCutting.DependencyInjection
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    ExcludeAggregates(scanner);
                    scanner.WithDefaultConventions();
                });

            this.AddMediatR(typeof(RegistryCollection));
        }

        private static void ExcludeAggregates(IAssemblyScanner scanner)
        {
            var agType = typeof(IAggregateRoot);

            var agTypes = typeof(RegistryCollection)
                .Assembly.GetTypes().Where(f => agType.IsAssignableFrom(f) && !f.IsAbstract)
                .ToList();

            agTypes.ForEach(ag => scanner.Exclude(f => f == ag));
        }
    }
}