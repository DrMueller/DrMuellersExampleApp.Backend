﻿using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.DrMuellersExampleApp.Domain.Infrastructure.ModelBase;

namespace Mmu.DrMuellersExampleApp.Domain.Infrastructure.Data.Repositories;

[SuppressMessage("Design", "CA1040:Avoid empty interfaces",
    Justification = "Marker interface for easier generic handling")]
public interface IRepository
{
}

[PublicAPI]
public interface IRepository<TAg> : IRepository
    where TAg : IAggregateRoot
{
    Task DeleteAsync(long id);

    Task InsertAsync(TAg entity);

    Task<IReadOnlyCollection<TAg>> LoadCollectionAsync(IAggregateSpecification<TAg> spec);

    Task<Maybe<TAg>> LoadSingleAsync(IAggregateSpecification<TAg> spec);

    Task<Maybe<TAg>> LoadSingleAsync(long id);
}