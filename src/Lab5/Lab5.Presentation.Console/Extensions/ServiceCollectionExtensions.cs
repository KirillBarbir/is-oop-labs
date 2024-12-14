using Lab5.Presentation.Console.Scenarios.Admin;
using Lab5.Presentation.Console.Scenarios.Admin.AdminScenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsolePresentation(this IServiceCollection services)
    {
        services.AddScoped<ScenarioRunner>();

        services.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        services.AddScoped<IAdminScenarioProvider, AccountCreationScenarioProvider>();
        return services;
    }
}