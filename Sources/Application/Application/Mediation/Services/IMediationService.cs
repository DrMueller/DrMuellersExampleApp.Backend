﻿using System.Threading.Tasks;
using Mmu.CleanDddSimple.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}