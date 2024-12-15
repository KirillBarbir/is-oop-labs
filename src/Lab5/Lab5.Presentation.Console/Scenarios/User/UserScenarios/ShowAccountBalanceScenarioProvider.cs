using Lab5.Application.Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class ShowAccountBalanceScenarioProvider : IUserScenarioProvider
{
    private readonly IShowAccountBalanceService _service;

    public ShowAccountBalanceScenarioProvider(IShowAccountBalanceService service)
    {
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IUserScenario? scenario)
    {
        scenario = new ShowAccountBalanceScenario(_service);
        return true;
    }
}