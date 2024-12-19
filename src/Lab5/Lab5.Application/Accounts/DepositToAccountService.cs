using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Accounts;

public class DepositToAccountService : IDepositToAccountService
{
    public Account? Account { get; set; }

    private readonly IAccountRepository _accountRepository;

    public DepositToAccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Deposit(long id, long amount)
    {
        if (Account is null)
        {
            return;
        }

        Account.Deposit(amount);
        _accountRepository.UpdateAccount(Account);
        _accountRepository.WriteOperation(Account.ShowHistory().Last());
    }
}