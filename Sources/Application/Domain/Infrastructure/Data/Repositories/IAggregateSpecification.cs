using System.Linq.Expressions;
using Mmu.DrMuellersExampleApp.Domain.Infrastructure.ModelBase;

namespace Mmu.DrMuellersExampleApp.Domain.Infrastructure.Data.Repositories
{
    public interface IAggregateSpecification<TAg>
        where TAg : IAggregateRoot
    {
        public Expression<Func<TAg, bool>> Filter { get; }
    }
}