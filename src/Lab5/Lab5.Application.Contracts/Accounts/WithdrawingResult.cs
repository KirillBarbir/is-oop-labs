namespace Lab5.Application.Contracts.Accounts;

public abstract record WithdrawingResult
{
    private WithdrawingResult() { }

    public sealed record Success : WithdrawingResult;

    public sealed record InsufficientBalance : WithdrawingResult;
}