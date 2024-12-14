using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User;

public class UserLoginScenario : IScenario
{
    private readonly IEnumerable<IScenarioProvider> _userScenarios;

    public UserLoginScenario(IEnumerable<IScenarioProvider> userScenarios)
    {
        _userScenarios = userScenarios;
    }

    public string Name => "User login";

    public void Run()
    {
        string accountNumber = AnsiConsole.Ask<string>("Enter  account number: ");

        string pin = AnsiConsole.Ask<string>("Enter pin: ");

        // TODO: check data via service
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> prompt = new SelectionPrompt<IScenario>()
            .Title("select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);
        IScenario scenario = AnsiConsole.Prompt(prompt);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _userScenarios)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}