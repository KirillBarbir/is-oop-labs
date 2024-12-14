using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Accounts;

public class UserAuthorisationService : IUserAuthorisationService
{
    private readonly Account _account;

    public UserAuthorisationService(Account account)
    {
        _account = account;
    }

    public AuthorisationResult Authorise(long pin)
    {
        if (_account.LogIn(pin))
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}