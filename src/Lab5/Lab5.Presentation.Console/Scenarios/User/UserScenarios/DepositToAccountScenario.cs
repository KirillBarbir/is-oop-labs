using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class DepositToAccountScenario : IUserScenario
{
    private readonly IDepositToAccountService _service;

    public DepositToAccountScenario(IDepositToAccountService service)
    {
        _service = service;
    }

    public string Name => "Deposit to account";

    public void Run(long id)
    {
        long amount = long.Parse(AnsiConsole.Ask<string>("Enter amount to deposit: "));

        _service.Deposit(id, amount);
        AnsiConsole.Ask<string>("Enter anything to proceed...");
    }
}