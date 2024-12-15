using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? GetAccountById(long id)
    {
        const string sql = """
                           select account_id, pin, amount
                           from accounts
                           where account_id = @id
                           """;
        const string sqlOperations = """
                           select account_id, amount, operation_type
                           from operations
                           where account_id = @id
                           """;
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        var account = new Account(
            id: reader.GetInt64(0),
            pin: reader.GetInt64(1),
            amount: reader.GetInt64(2));
        using NpgsqlConnection operationConnection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using NpgsqlCommand operationCommand = new NpgsqlCommand(sqlOperations, operationConnection).AddParameter("id", id);
        using NpgsqlDataReader operationReader = operationCommand.ExecuteReader();
        var operations = new List<Operation>();
        while (operationReader.Read())
        {
            operations.Add(new Operation(operationReader.GetInt64(1), operationReader.GetFieldValue<OperationType>(2)));
        }

        account.InitializeHistory(operations);
        return account;
    }

    public void UpdateAccount(Account account)
    {
        const string sql = """
                           update accounts
                           Set amount = @amount
                           where account_id = @id
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", account.Id)
            .AddParameter("amount", account.Amount);
        command.ExecuteNonQuery();
    }

    public void WriteAccount(Account account)
    {
        const string sql = """
                           insert into accounts
                           values (@id, @pin, @amount)
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", account.Id)
            .AddParameter("pin", account.Pin)
            .AddParameter("amount", account.Amount);
        command.ExecuteNonQuery();
    }

    public void WriteOperation(long id, long amount, OperationType operationType)
    {
        const string sql = """
                           insert into Operations (account_id, amount, operation_type)
                           values (@id, @amount, @operationType)
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        var idParameter = new NpgsqlParameter("@id", id);
        var amountParameter = new NpgsqlParameter("@amount", amount);
        var typeParameter = new NpgsqlParameter("@operationType", operationType);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.Add(idParameter);
        command.Parameters.Add(amountParameter);
        command.Parameters.Add(typeParameter);
        command.ExecuteNonQuery();
    }
}