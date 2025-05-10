using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User;

public interface IUserScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IUserScenario? scenario);
}