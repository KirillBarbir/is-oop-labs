using Lab5.Application.Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class WithdrawAccountBalanceScenarioProvider : IUserScenarioProvider
{
    private readonly IWithdrawAccountBalanceService _service;

    public WithdrawAccountBalanceScenarioProvider(IWithdrawAccountBalanceService service)
    {
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IUserScenario? scenario)
    {
        scenario = new WithdrawAccountBalanceScenario(_service);
        return true;
    }
}