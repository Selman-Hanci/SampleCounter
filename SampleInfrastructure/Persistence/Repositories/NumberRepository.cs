using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SampleDomain.Entities;
using SampleInfrastructure.Persistence.Contexts;
using SampleInfrastructure.Persistence.Repositories.Interfaces;

namespace SampleInfrastructure.Persistence.Repositories
{
    public class NumberRepository : INumberRepository
    {
        private readonly DefaultDBContext _context;

        public NumberRepository(DefaultDBContext context)
        {
            _context = context;
        }

        public async Task<Number?> GetLastNumberAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Numbers.AsNoTracking().
                FirstOrDefaultAsync(cancellationToken);
        }
    }
}