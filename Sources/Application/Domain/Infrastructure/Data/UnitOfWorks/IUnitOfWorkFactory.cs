namespace Mmu.DrMuellersExampleApp.Domain.Infrastructure.Data.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}