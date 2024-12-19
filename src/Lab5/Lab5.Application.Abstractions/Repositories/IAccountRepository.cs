using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? GetAccountById(long id);

    void UpdateAccount(Account account);

    void WriteAccount(Account account);

    void WriteOperation(Operation operation);
}