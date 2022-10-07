using System;
using System.Data;
using System.Reflection;
using SampleDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SampleInfrastructure.Persistence.Contexts
{
    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions<DefaultDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Number> Numbers { get; set; }
    }
}

