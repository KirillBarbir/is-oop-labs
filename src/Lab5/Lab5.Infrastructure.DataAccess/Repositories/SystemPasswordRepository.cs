using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class SystemPasswordRepository : ISystemPasswordRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public SystemPasswordRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public AuthorisationResult CheckPassword(string password)
    {
        const string sql = """
                           select *
                           from system_password
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return new AuthorisationResult.Failure();
        }

        if (reader.GetString(1) == password)
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}