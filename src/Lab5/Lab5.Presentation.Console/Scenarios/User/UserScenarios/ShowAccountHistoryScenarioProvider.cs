using Lab5.Application.Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class ShowAccountHistoryScenarioProvider : IUserScenarioProvider
{
    private readonly IShowAccountHistoryService _service;

    public ShowAccountHistoryScenarioProvider(IShowAccountHistoryService service)
    {
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IUserScenario? scenario)
    {
        scenario = new ShowAccountHistoryScenario(_service);
        return true;
    }
}