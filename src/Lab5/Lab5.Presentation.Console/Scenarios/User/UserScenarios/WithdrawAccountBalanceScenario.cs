using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class WithdrawAccountBalanceScenario : IUserScenario
{
    private readonly IWithdrawAccountBalanceService _service;

    public WithdrawAccountBalanceScenario(IWithdrawAccountBalanceService service)
    {
        _service = service;
    }

    public string Name => "Withdraw from account";

    public void Run(long id)
    {
        long amount = long.Parse(AnsiConsole.Ask<string>("Enter amount to withdraw: "));

        WithdrawingResult result = _service.Withdraw(id, amount);

        string message = result switch
        {
            WithdrawingResult.Success => "Success",
            WithdrawingResult.InsufficientBalance => "Insufficient balance",
            _ => "Unknown Error",

            // _ => throw new ArgumentOutOfRangeException(nameof(result), result, "Unknown result type."),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Enter anything to proceed...");
    }
}