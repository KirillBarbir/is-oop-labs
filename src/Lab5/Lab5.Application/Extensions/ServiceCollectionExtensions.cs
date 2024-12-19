using Lab5.Application.Accounts;
using Lab5.Application.Admins;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAdminAuthorisationService, AdminAuthorisationService>();
        services.AddScoped<IAccountCreationService, AccountCreationService>();
        services.AddScoped<IUserAuthorisationService, UserAuthorisationService>();

        services.AddScoped<DepositToAccountService>();
        services.AddScoped<IDepositToAccountService>(
            p => p.GetRequiredService<DepositToAccountService>());

        services.AddScoped<ShowAccountBalanceService>();
        services.AddScoped<IShowAccountBalanceService>(
            p => p.GetRequiredService<ShowAccountBalanceService>());

        services.AddScoped<ShowAccountHistoryService>();
        services.AddScoped<IShowAccountHistoryService>(
            p => p.GetRequiredService<ShowAccountHistoryService>());

        services.AddScoped<WithdrawAccountBalanceService>();
        services.AddScoped<IWithdrawAccountBalanceService>(
            p => p.GetRequiredService<WithdrawAccountBalanceService>());

        services.AddScoped<IAccountService, IDepositToAccountService>(p => p.GetRequiredService<DepositToAccountService>());
        services.AddScoped<IAccountService, IShowAccountBalanceService>(p => p.GetRequiredService<ShowAccountBalanceService>());
        services.AddScoped<IAccountService, IShowAccountHistoryService>(p => p.GetRequiredService<ShowAccountHistoryService>());
        services.AddScoped<IAccountService, IWithdrawAccountBalanceService>(p => p.GetRequiredService<WithdrawAccountBalanceService>());
        return services;
    }
}