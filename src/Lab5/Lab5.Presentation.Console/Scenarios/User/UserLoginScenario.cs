using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User;

public class UserLoginScenario : IScenario
{
    private readonly IUserAuthorisationService _userAuthorisationService;
    private readonly IEnumerable<IUserScenarioProvider> _userScenarios;

    public UserLoginScenario(IUserAuthorisationService userAuthorisationService, IEnumerable<IUserScenarioProvider> userScenarios)
    {
        _userAuthorisationService = userAuthorisationService;

        _userScenarios = userScenarios;
    }

    public string Name => "User login";

    public void Run()
    {
        long accountNumber = long.Parse(AnsiConsole.Ask<string>("Enter  account number: "));

        long pin = long.Parse(AnsiConsole.Ask<string>("Enter pin: "));

        AuthorisationResult result = _userAuthorisationService.Authorise(accountNumber, pin);

        string message = result switch
        {
            AuthorisationResult.Success => "Success",
            AuthorisationResult.Failure => "Failure",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        if (message is not "Success")
        {
            return;
        }

        IEnumerable<IUserScenario> scenarios = GetScenarios();

        SelectionPrompt<IUserScenario> prompt = new SelectionPrompt<IUserScenario>()
            .Title("select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);
        IUserScenario scenario = AnsiConsole.Prompt(prompt);
        scenario.Run(accountNumber);
    }

    private IEnumerable<IUserScenario> GetScenarios()
    {
        foreach (IUserScenarioProvider provider in _userScenarios)
        {
            if (provider.TryGetScenario(out IUserScenario? scenario))
                yield return scenario;
        }
    }
}