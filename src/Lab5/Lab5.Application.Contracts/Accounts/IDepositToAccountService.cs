namespace Lab5.Application.Contracts.Accounts;

public interface IDepositToAccountService : IAccountService
{
    void Deposit(long id, long amount);
}