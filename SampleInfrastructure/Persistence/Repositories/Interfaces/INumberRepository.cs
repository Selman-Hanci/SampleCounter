using System;
using SampleDomain.Entities;

namespace SampleInfrastructure.Persistence.Repositories.Interfaces
{
    public interface INumberRepository
    {
        Task<Number?> GetLastNumberAsync(CancellationToken cancellationToken = default);
    }
}

