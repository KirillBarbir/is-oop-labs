using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Accounts;

public class ShowAccountBalanceService : IShowAccountBalanceService
{
    public Account? Account { get; set; }

    public long ShowAccountBalance(long id)
    {
        if (Account is null)
        {
            throw new ArgumentException($"Account with id {id} does not exist");
        }

        return Account.Amount;
    }
}