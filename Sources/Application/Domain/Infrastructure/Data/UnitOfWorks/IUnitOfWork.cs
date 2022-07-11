using Mmu.DrMuellersExampleApp.Domain.Infrastructure.Data.Repositories;

namespace Mmu.DrMuellersExampleApp.Domain.Infrastructure.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}