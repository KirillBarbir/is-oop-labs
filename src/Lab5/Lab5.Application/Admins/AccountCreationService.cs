using Lab5.Application.Contracts.Admins;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Admins;

public class AccountCreationService : IAccountCreationService
{
    public Account CreateAccount(long id, long pin) // TODO: finish implementation
    {
        return new Account(id, pin);
    }
}