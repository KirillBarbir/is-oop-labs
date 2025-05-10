using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public interface IAdminScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IAdminScenario? scenario);
}