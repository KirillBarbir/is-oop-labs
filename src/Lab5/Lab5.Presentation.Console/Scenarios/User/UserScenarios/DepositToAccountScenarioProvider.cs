using Lab5.Application.Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class DepositToAccountScenarioProvider : IUserScenarioProvider
{
    private readonly IDepositToAccountService _service;

    public DepositToAccountScenarioProvider(IDepositToAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IUserScenario? scenario)
    {
        scenario = new DepositToAccountScenario(_service);
        return true;
    }
}