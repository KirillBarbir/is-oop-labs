using Lab5.Application.Contracts.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminAuthorisationService _service;
    private readonly IEnumerable<IAdminScenarioProvider> _scenarios;

    public AdminLoginScenarioProvider(
        IAdminAuthorisationService service,
        IEnumerable<IAdminScenarioProvider> scenarios)
        {
        _service = service;
        _scenarios = scenarios;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new AdminLoginScenario(_service, _scenarios);
        return true;
    }
}