using Microsoft.EntityFrameworkCore;
using SampleInfrastructure.Persistence.Contexts;

namespace SampleAPI.Extensions
{
    public static class MigrationExtension
    {
        public static void ExecuteDbMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var defaultDbContext = scope.ServiceProvider.GetRequiredService<DefaultDBContext>();
            defaultDbContext.Database.Migrate();
        }
    }
}

