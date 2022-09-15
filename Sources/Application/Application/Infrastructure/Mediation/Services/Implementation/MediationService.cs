using MediatR;
using Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Models;

namespace Mmu.DrMuellersExampleApp.Application.Infrastructure.Mediation.Services.Implementation;

public class MediationService : IMediationService
{
    private readonly IMediator _mediator;

    public MediationService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<T> SendAsync<T>(ICommand<T> command)
    {
        return await _mediator.Send(command);
    }

    public async Task SendAsync(ICommand command)
    {
        await _mediator.Send(command);
    }

    public async Task<T> SendAsync<T>(IQuery<T> query)
    {
        return await _mediator.Send(query);
    }
}