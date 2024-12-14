using Lab5.Application.Models.Operations;

namespace Lab5.Application.Models.Accounts;

public class Account
{
    private readonly long _pin;
    private readonly List<Operation> _history = [];

    public Account(long id, long pin, long amount = 0)
    {
        Id = id;
        _pin = pin;
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
        _history.Add(new Operation(Amount, OperationType.TopUp));
    }

    public bool LogIn(long pin)
    {
        return pin == _pin;
    }

    public IEnumerable<Operation> ShowHistory()
    {
        return _history;
    }
}