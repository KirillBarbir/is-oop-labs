using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Accounts;

public class ShowAccountHistoryService : IShowAccountHistoryService
{
    public Account? Account { get; set; }

    public IEnumerable<Operation> ShowHistory(long id)
    {
        if (Account is null)
        {
            throw new ArgumentException($"Account with id {id} does not exist");
        }

        return Account.ShowHistory();
    }
}