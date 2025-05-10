using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Accounts;

public class UserAuthorisationService : IUserAuthorisationService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEnumerable<IAccountService> _accountServices;

    public UserAuthorisationService(
        IAccountRepository accountRepository,
        IEnumerable<IAccountService> accountServices)
    {
        _accountRepository = accountRepository;
        _accountServices = accountServices;
    }

    public AuthorisationResult Authorise(long accountNumber, long pin)
    {
        Account? account = _accountRepository.GetAccountById(accountNumber);
        if (account is null)
        {
            return new AuthorisationResult.Failure();
        }

        foreach (IAccountService service in _accountServices)
        {
            service.Account = account;
        }

        if (account.LogIn(pin))
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}