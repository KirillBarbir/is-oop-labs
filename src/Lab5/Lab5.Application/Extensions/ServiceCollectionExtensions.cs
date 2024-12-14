using Lab5.Application.Admins;
using Lab5.Application.Contracts.Admins;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAdminAuthorisationService, AdminAuthorisationService>();
        services.AddScoped<IAccountCreationService, AccountCreationService>();
        services.AddScoped<CurrentPasswordManager>();
        services.AddScoped<ICurrentPasswordService>(p => p.GetRequiredService<CurrentPasswordManager>());
        return services;
    }
}