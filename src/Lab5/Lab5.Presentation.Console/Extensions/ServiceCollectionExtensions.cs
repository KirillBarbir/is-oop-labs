using Lab5.Presentation.Console.Scenarios.Admin;
using Lab5.Presentation.Console.Scenarios.Admin.AdminScenarios;
using Lab5.Presentation.Console.Scenarios.User;
using Lab5.Presentation.Console.Scenarios.User.UserScenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsolePresentation(this IServiceCollection services)
    {
        services.AddScoped<ScenarioRunner>();

        services.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();

        services.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        services.AddScoped<IAdminScenarioProvider, AccountCreationScenarioProvider>();
        services.AddScoped<IUserScenarioProvider, DepositToAccountScenarioProvider>();
        services.AddScoped<IUserScenarioProvider, ShowAccountBalanceScenarioProvider>();
        services.AddScoped<IUserScenarioProvider, ShowAccountHistoryScenarioProvider>();
        services.AddScoped<IUserScenarioProvider, WithdrawAccountBalanceScenarioProvider>();
        return services;
    }
}