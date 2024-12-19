namespace Lab5.Application.Contracts.Accounts;

public interface IWithdrawAccountBalanceService : IAccountService
{
    WithdrawingResult Withdraw(long id, long amount);
}