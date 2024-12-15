using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Accounts;

public class UserAuthorisationService : IUserAuthorisationService
{
    private readonly IAccountRepository _accountRepository;
    private readonly DepositToAccountService _depositToAccountService;
    private readonly ShowAccountBalanceService _showAccountBalanceService;
    private readonly ShowAccountHistoryService _showAccountHistoryService;
    private readonly WithdrawAccountBalanceService _withdrawAccountBalanceService;

    public UserAuthorisationService(
        IAccountRepository accountRepository,
        DepositToAccountService depositToAccountService,
        ShowAccountBalanceService showAccountBalanceService,
        ShowAccountHistoryService showAccountHistoryService,
        WithdrawAccountBalanceService withdrawAccountBalanceService)
    {
        _accountRepository = accountRepository;
        _depositToAccountService = depositToAccountService;
        _showAccountBalanceService = showAccountBalanceService;
        _showAccountHistoryService = showAccountHistoryService;
        _withdrawAccountBalanceService = withdrawAccountBalanceService;
    }

    public AuthorisationResult Authorise(long accountNumber, long pin)
    {
        Account? account = _accountRepository.GetAccountById(accountNumber);
        if (account is null)
        {
            return new AuthorisationResult.Failure();
        }

        _depositToAccountService.Account = account;
        _showAccountBalanceService.Account = account;
        _showAccountHistoryService.Account = account;
        _withdrawAccountBalanceService.Account = account;
        if (account.LogIn(pin))
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}