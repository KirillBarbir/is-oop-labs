using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface IAccountCreationService
{
    Account CreateAccount(long id, long pin);
}