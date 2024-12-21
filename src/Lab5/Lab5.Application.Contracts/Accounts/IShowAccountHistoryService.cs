using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IShowAccountHistoryService : IAccountService
{
    IEnumerable<Operation> ShowHistory(long id);
}