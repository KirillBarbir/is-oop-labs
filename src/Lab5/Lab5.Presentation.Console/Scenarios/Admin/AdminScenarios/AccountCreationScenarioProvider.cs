using Lab5.Application.Contracts.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin.AdminScenarios;

public class AccountCreationScenarioProvider : IAdminScenarioProvider
{
    private readonly IAccountCreationService _accountCreationService;

    public AccountCreationScenarioProvider(IAccountCreationService accountCreationService)
    {
        _accountCreationService = accountCreationService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IAdminScenario? scenario)
    {
        scenario = new AccountCreationScenario(_accountCreationService);
        return true;
    }
}