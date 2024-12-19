namespace Lab5.Application.Contracts.Accounts;

public interface IShowAccountBalanceService : IAccountService
{
    long ShowAccountBalance(long id);
}