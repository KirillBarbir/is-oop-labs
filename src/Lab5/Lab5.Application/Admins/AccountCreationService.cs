using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Admins;

public class AccountCreationService : IAccountCreationService
{
    private readonly IAccountRepository _accountRepository;

    public AccountCreationService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void CreateAccount(long id, long pin)
    {
        _accountRepository.WriteAccount(new Account(id, pin));
    }
}