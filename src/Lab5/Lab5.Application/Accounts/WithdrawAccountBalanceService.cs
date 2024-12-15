using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Accounts;

public class WithdrawAccountBalanceService : IWithdrawAccountBalanceService
{
    public Account? Account { get; set; }

    private readonly IAccountRepository _accountRepository;

    public WithdrawAccountBalanceService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public WithdrawingResult Withdraw(long id, long amount)
    {
        if (Account is null)
        {
            throw new ArgumentException($"Account with id {id} does not exist");
        }

        if (Account.Withdraw(amount))
        {
            _accountRepository.UpdateAccount(Account);
            _accountRepository.WriteOperation(id, amount, OperationType.Withdraw);
            return new WithdrawingResult.Success();
        }

        return new WithdrawingResult.InsufficientBalance();
    }
}