using Lab5.Application.Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserAuthorisationService _service;

    private readonly IEnumerable<IUserScenarioProvider> _scenarios;

    public UserLoginScenarioProvider(
        IUserAuthorisationService service,
        IEnumerable<IUserScenarioProvider> scenarios)
    {
        _service = service;
        _scenarios = scenarios;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new UserLoginScenario(_service, _scenarios);
        return true;
    }
}