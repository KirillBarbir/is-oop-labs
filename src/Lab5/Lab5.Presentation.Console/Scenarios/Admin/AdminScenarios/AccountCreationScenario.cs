using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin.AdminScenarios;

public class AccountCreationScenario : IAdminScenario
{
    private readonly IAccountCreationService _accountCreationService;

    public AccountCreationScenario(IAccountCreationService accountCreationService)
    {
        _accountCreationService = accountCreationService;
    }

    public string Name => "Create account";

    public void Run()
    {
        long number = long.Parse(AnsiConsole.Ask<string>("Create number: "));
        long pin = long.Parse(AnsiConsole.Ask<string>("Create pin: "));

        _accountCreationService.CreateAccount(number, pin);
        AnsiConsole.Ask<string>("Enter anything to proceed...");
    }
}