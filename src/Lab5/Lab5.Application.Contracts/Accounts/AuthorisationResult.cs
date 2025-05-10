namespace Lab5.Application.Contracts.Accounts;

public abstract record AuthorisationResult
{
    private AuthorisationResult() { }

    public sealed record Success : AuthorisationResult;

    public sealed record Failure : AuthorisationResult;
}