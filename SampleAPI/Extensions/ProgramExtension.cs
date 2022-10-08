using Microsoft.EntityFrameworkCore;
using SampleAPI.Middlewares;
using SampleBusiness.Services;
using SampleBusiness.Services.Interfaces;
using SampleInfrastructure.Persistence.Contexts;
using SampleInfrastructure.Persistence.Repositories;
using SampleInfrastructure.Persistence.Repositories.Interfaces;

namespace SampleAPI.Extensions;

public static class ProgramExtension
{
    private const string SqlServerConnectionString = "SqlServerConnection";
    
    public static void RegisterDBServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultDBContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(SqlServerConnectionString));
        });
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<INumberRepository, NumberRepository>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<ICalculatorService, CalculatorService>();
        services.AddTransient<ILogService, LogService>();
    }

    public static void RegisterMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<LoggingMiddleware>();
    }
}

