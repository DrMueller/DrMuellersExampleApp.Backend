using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services;

public interface IMediationService
{
    Task<T> SendAsync<T>(ICommand<T> command);

    Task SendAsync(ICommand command);

    Task<T> SendAsync<T>(IQuery<T> query);
}