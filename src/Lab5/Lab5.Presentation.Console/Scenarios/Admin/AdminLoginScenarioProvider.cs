using Lab5.Application.Contracts.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminAuthorisationService _service;

    private readonly ICurrentPasswordService _currentPassword;

    private readonly IEnumerable<IAdminScenarioProvider> _scenarios;

    public AdminLoginScenarioProvider(
        IAdminAuthorisationService service,
        ICurrentPasswordService password,
        IEnumerable<IAdminScenarioProvider> scenarios)
        {
        _service = service;
        _currentPassword = password;
        _scenarios = scenarios;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentPassword.Password is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_service, _scenarios);
        return true;
    }
}