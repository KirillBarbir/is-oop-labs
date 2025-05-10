using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.DataAccess.Plugins;
using Lab5.Infrastructure.DataAccess.Repositories;
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

        services.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ISystemPasswordRepository, SystemPasswordRepository>();
        return services;
    }
}