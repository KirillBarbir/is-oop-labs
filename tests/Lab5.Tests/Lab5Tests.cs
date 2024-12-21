using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class Lab5Tests
{
    [Fact]
    public void CorrectWithdrawingTest()
    {
        // Arrange
        IAccountRepository mock = Substitute.For<IAccountRepository>();
        var service = new WithdrawAccountBalanceService(mock);
        var account = new Account(1, 1111, 1000);
        service.Account = account;

        // Act
        WithdrawingResult result = service.Withdraw(1, 100);

        // Assert
        Assert.Equal(new WithdrawingResult.Success(), result);
        Assert.Equal(900, account.Amount);
    }

    [Fact]
    public void IncorrectWithdrawingTest()
    {
        // Arrange
        IAccountRepository mock = Substitute.For<IAccountRepository>();
        var service = new WithdrawAccountBalanceService(mock);
        var account = new Account(1, 1111, 1000);
        service.Account = account;

        // Act
        WithdrawingResult result = service.Withdraw(1, 10000);

        // Assert
        Assert.Equal(new WithdrawingResult.InsufficientBalance(), result);
    }

    [Fact]
    public void DepositingTest()
    {
        // Arrange
        IAccountRepository mock = Substitute.For<IAccountRepository>();
        var service = new DepositToAccountService(mock);
        var account = new Account(1, 1111);
        service.Account = account;

        // Act
        service.Deposit(1, 100);

        // Assert
        Assert.Equal(100, account.Amount);
    }
}