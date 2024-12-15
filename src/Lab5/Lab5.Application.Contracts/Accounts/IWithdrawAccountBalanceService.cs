using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Accounts;

public interface IWithdrawAccountBalanceService
{
    Account? Account { get; }

    WithdrawingResult Withdraw(long id, long amount);
}