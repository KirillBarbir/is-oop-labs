using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminAuthorisationService _adminAuthorisationService;

    private readonly IEnumerable<IAdminScenarioProvider> _adminScenarios;

    public AdminLoginScenario(
        IAdminAuthorisationService adminAuthorisationService,
        IEnumerable<IAdminScenarioProvider> adminScenarios)
    {
        _adminAuthorisationService = adminAuthorisationService;

        _adminScenarios = adminScenarios;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter password: ");

        AuthorisationResult result = _adminAuthorisationService.GetAuthorisationResult(password);
        string message = result switch
        {
            AuthorisationResult.Success => "Success",
            AuthorisationResult.Failure => "Invalid password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        if (message != "Success")
        {
            throw new ApplicationException(message);
        }

        IEnumerable<IAdminScenario> scenarios = GetScenarios();

        SelectionPrompt<IAdminScenario> prompt = new SelectionPrompt<IAdminScenario>()
            .Title("select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);
        IAdminScenario scenario = AnsiConsole.Prompt(prompt);
        scenario.Run();
    }

    private IEnumerable<IAdminScenario> GetScenarios()
    {
        foreach (IAdminScenarioProvider provider in _adminScenarios)
        {
            if (provider.TryGetScenario(out IAdminScenario? scenario))
                yield return scenario;
        }
    }
}