using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class ShowAccountBalanceScenario : IUserScenario
{
    private readonly IShowAccountBalanceService _service;

    public ShowAccountBalanceScenario(IShowAccountBalanceService service)
    {
        _service = service;
    }

    public string Name => "Show account balance";

    public void Run(long id)
    {
        AnsiConsole.WriteLine(_service.ShowAccountBalance(id));
        AnsiConsole.Ask<string>("Enter anything to proceed...");
    }
}