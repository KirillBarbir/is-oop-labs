using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? GetAccountById(long id);
}