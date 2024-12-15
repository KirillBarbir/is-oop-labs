using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Accounts;

public interface IShowAccountBalanceService
{
    Account? Account { get; }

    long ShowAccountBalance(long id);
}