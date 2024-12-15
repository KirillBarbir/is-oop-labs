using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Accounts;

public interface IDepositToAccountService
{
    Account? Account { get; }

    void Deposit(long id, long amount);
}