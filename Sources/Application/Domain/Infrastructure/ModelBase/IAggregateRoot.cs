using System.Diagnostics.CodeAnalysis;

namespace Mmu.DrMuellersExampleApp.Domain.Infrastructure.ModelBase
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface")]
    public interface IAggregateRoot
    {
    }
}