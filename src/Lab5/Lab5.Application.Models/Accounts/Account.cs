using Lab5.Application.Models.Operations;

namespace Lab5.Application.Models.Accounts;

public class Account
{
    public long Pin { get; }

    private readonly ICollection<Operation> _history = [];

    public Account(long id, long pin, long amount = 0)
    {
        Id = id;
        Pin = pin;
        Amount = amount;
    }

    public long Id { get; }

    public long Amount { get; private set; }

    public bool Withdraw(long amount)
    {
        if (Amount < amount)
        {
            return false;
        }

        Amount -= amount;
        _history.Add(new Operation(Amount, OperationType.Withdraw));
        return true;
    }

    public void Deposit(long amount)
    {
        Amount += amount;
        _history.Add(new Operation(Amount, OperationType.Deposit));
    }

    public bool LogIn(long pin)
    {
        return pin == Pin;
    }

    public IEnumerable<Operation> ShowHistory()
    {
        return _history;
    }

    public void InitializeHistory(IEnumerable<Operation> history)
    {
        if (_history.Count != 0)
        {
            return;
        }

        foreach (Operation operation in history)
        {
            _history.Add(operation);
        }
    }
}