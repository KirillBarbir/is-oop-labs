namespace Lab5.Application.Contracts.Accounts;

public interface IWithdrawAccountBalanceService
{
    void Withdraw(long amount);
}