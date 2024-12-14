using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> configuration)
    {
        services.AddPlatform();
        services.AddPlatformPostgres(builder => builder.Configure(configuration));
        services.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);
        return services;
    }
}