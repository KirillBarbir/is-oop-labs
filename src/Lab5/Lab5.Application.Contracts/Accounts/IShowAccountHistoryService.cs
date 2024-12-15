using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IShowAccountHistoryService
{
    Account? Account { get; }

    IEnumerable<Operation> ShowHistory(long id);
}